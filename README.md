# XmlUtils
###Generic XML-To-Entity Parser for C#

####Installation (NuGet)
> Install-Package BourneAgain.Utility.XmlUtils

####Usage
1. Create model
```C#
[XmlData("User")] // Define single entity element name
class SomeEntity
    {
        [XmlData("UserName")] // "UserName" - name of element
        public string Name { get; set; }
        [XmlData("LastName")] 
        public string LastName { get; set; }
        [XmlData("Age", ParentName = "Details")] // Optional parent element name
        public int Age { get; set; }
    }
```
2. Translate file
```C#
IEnumerable<SomeEntity> entities = XmlDataTranslator<SomeEntity>.Translate(filePath);
```

See example in XmlUtils.Example project
