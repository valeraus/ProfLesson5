using System;
using System.IO;
using System.Xml;

namespace Task3
{
    /*
    З файлу TelephoneBook.xml (файл має бути створений в процесі виконання додаткового завдання) 
    виведіть на екран тільки номери телефонів.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            var xmlWriter = new XmlTextWriter("TelephoneBook.xml", null);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("MyContacts");
            xmlWriter.WriteStartElement("Contact");
            xmlWriter.WriteStartAttribute("TelephoneNumber");
            xmlWriter.WriteString("(093)*******");
            xmlWriter.WriteEndAttribute();
            xmlWriter.WriteString("Alex Alexeev");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.Close();

            Console.SetWindowSize(80, 45);

            FileStream stream = new FileStream("TelephoneBook.xml", FileMode.Open);

            XmlTextReader xmlReader = new XmlTextReader(stream);

            while (xmlReader.Read())
            {
                if (xmlReader.HasAttributes)
                {
                    if (xmlReader.Name.Equals("Contact"))
                    {
                        Console.WriteLine("<{0}>", xmlReader.GetAttribute("TelephoneNumber"));
                    }
                }
            }

            xmlReader.Close();

            // Delay.
            Console.ReadKey();
        }
    }
}