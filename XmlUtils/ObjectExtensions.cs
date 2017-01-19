using System;

namespace XmlUtils
{
    public static class ObjectExtensions
    {
        public static void SetPropertyValue(this object entity, string propertyName, object value)
        {
            var propertyInfo = entity.GetType().GetProperty(propertyName);
            var propertyValue = value;

            if (propertyInfo.PropertyType == typeof(int))
            {
                propertyValue = Int32.Parse(value.ToString());
            }
            else if (propertyInfo.PropertyType == typeof(bool))
            {
                propertyValue = Boolean.Parse(value.ToString());
            }

            propertyInfo.SetValue(entity, propertyValue);
        }
    }
}
