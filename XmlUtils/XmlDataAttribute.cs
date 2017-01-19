using System;

namespace XmlUtils
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class XmlDataAttribute : Attribute
    {
        private readonly string _elementName;
        private string _parentElementName;

        public virtual string Name
        {
            get { return _elementName; }
        }

        public virtual string ParentName
        {
            get { return _parentElementName; }
            set { _parentElementName = value; }
        }

        public XmlDataAttribute(string elementName)
        {
            _elementName = elementName;
            _parentElementName = null;
        }
    }
}
