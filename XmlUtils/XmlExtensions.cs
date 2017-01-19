using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XmlUtils
{
    public static class XmlExtensions
    {
        public static XElement GetDescendantByName(this XElement parentElement, string descendantName)
        {
            return parentElement
                .Descendants()
                .FirstOrDefault(e => e.Name.LocalName.Equals(descendantName, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<XElement> GetDescendantsByName(this XElement parentElement, string descendantName)
        {
            return parentElement
                .Descendants()
                .Where(e => e.Name.LocalName.Equals(descendantName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
