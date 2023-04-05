using System;
using System.IO;
using System.Xml;

namespace Task2
{
    /*Створіть додаток, який виведе на екран інформацію про вказаний .xml файл
     Створіть .xml, який відповідає таким вимогам:
        • Ім’я файлу: TelephoneBook.xml
        • Кореневий елемент: “MyContacts”
        • Тег “Contact”, і він повинен містити ім'я контакту та атрибут “TelephoneNumber” зі значенням номера телефону.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 45);

            FileStream stream = new FileStream("TelephoneBook.xml", FileMode.Open);

            XmlTextReader xmlReader = new XmlTextReader(stream);

            while (xmlReader.Read())
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10}",
                    xmlReader.NodeType,
                    xmlReader.Name,
                    xmlReader.Value);
            }

            xmlReader.Close();

            // Delay.
            Console.ReadKey();
        }
    }
}