using System;
using System.Collections.Generic;

namespace XmlUtils.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<SomeEntity> entities = XmlDataTranslator<SomeEntity>.Translate(@"..\..\test.xml");
            foreach (var entity in entities)
            {
                Console.WriteLine($"{entity.Name} {entity.LastName}, Age {entity.Age}");
            }

            Console.ReadKey();
        }
    }

    [XmlData("User")]
    class SomeEntity
    {
        [XmlData("UserName")]
        public string Name { get; set; }
        [XmlData("LastName")]
        public string LastName { get; set; }
        [XmlData("Age")]
        public int Age { get; set; }
    }
}
