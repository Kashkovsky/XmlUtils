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
        [XmlData("UserName", ParentName = "User")] // "UserName" - name of element
        public string Name { get; set; }
        [XmlData("LastName", ParentName = "User")] // ParentName - optional name of parent element
        public string LastName { get; set; }
        [XmlData("Age", ParentName = "User")]
        public int Age { get; set; }
    }
```
2. Translate file
```C#
IEnumerable<SomeEntity> entities = XmlDataTranslator<SomeEntity>.Translate(filePath);
```
