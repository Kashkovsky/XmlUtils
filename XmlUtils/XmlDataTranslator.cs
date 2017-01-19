using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XmlUtils
{
    public static class XmlDataTranslator<T> where T : class
    {
        public static IEnumerable<T> Translate(string path)
        {
            var doc = XDocument.Load(path);

            return TranslateDoc(doc);
        }
        public static IEnumerable<T> Translate(Stream xmlStream)
        {
            var doc = XDocument.Load(xmlStream);

            return TranslateDoc(doc);
        }

        private static IEnumerable<T> TranslateDoc(XDocument doc)
        {
            var root = doc.Root;
            var entityType = typeof(T);

            if (root == null)
            {
                return new T[0];
            }

            var entityClassAttribute =
                entityType.GetCustomAttributes(typeof(XmlDataAttribute), false).FirstOrDefault() as XmlDataAttribute;

            var singleEntityElementName = entityClassAttribute?.Name;

            var entityRecords = singleEntityElementName != null
                ? root.GetDescendantsByName(singleEntityElementName).ToArray()
                : root.Descendants();

            if (!entityRecords.Any())
            {
                return new T[0];
            }

            var mapping = GetPropertyAttributes().ToArray();

            return entityRecords
                .Select(entity => ParseEntity(entity, mapping));
        }
        private static T ParseEntity(
            XElement entityElement,
            IEnumerable<KeyValuePair<string, Tuple<string, string>>> mapping)
        {
            var entity = Activator.CreateInstance<T>();

            foreach (var map in mapping)
            {
                var parentElement = !string.IsNullOrEmpty(map.Value.Item2)
                    ? entityElement.GetDescendantByName(map.Value.Item2)
                    : entityElement;

                var element = parentElement.GetDescendantByName(map.Value.Item1);

                if (element != null)
                {
                    entity.SetPropertyValue(map.Key, element.Value);
                }
            }

            return entity;
        }

        private static IEnumerable<KeyValuePair<string, Tuple<string, string>>> GetPropertyAttributes()
        {
            var result = new Dictionary<string, Tuple<string, string>>();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var xmlMapping = prop.GetCustomAttributes(typeof(XmlDataAttribute), false)
                    .FirstOrDefault() as XmlDataAttribute;

                if (xmlMapping != null)
                {
                    result.Add(prop.Name, new Tuple<string, string>(xmlMapping.Name, xmlMapping.ParentName));
                }
            }

            return result;
        }
    }
}
