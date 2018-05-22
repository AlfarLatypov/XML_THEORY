using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XML_THEORY
{
    class Program
    {

        /*Курс: Платформа Microsoft .NET и язык программирования C#

          Тема: Основы XML.

          1.	Прочитать содержимое XML файла со списком последних новостей по ссылке https://habrahabr.ru/rss/interesting/
            Создать класс Item со свойствами: Title, Link, Description, PubDate.
            Создать коллекцию типа List<Item> и записать в нее данные из файла.

          2. На основании задания 1, сериализовать лист полученных объектов в XML и записать в файл.
*/

        //НАЧАЛО ДОМАШНЕЙ РАБОТЫ



        /* 1.	Прочитать содержимое XML файла со списком последних новостей по ссылке https://habrahabr.ru/rss/interesting/
        Создать класс Item со свойствами: Title, Link, Description, PubDate.
        Создать коллекцию типа List<Item> и записать в нее данные из файла.*/
        public class HabrNews
        {
            public string title { get; set; }
            public string lint { get; set; }
            public string Description { get; set; }
            public DateTime PubDate { get; set; }

        }




        static void Main(string[] args)
        {

            List<HabrNews> habrNews = new List<HabrNews>();





            //----------------------------------------------------------//
            XmlDocument doc1 = new XmlDocument();
            doc1.Load("https://habrahabr.ru/rss/interesting/");

            var rootElement = doc1.DocumentElement; //vozvrashaet root element // rootElement nazuvaetsya RSS

            foreach (XmlNode item in rootElement.ChildNodes)
            {
                Console.WriteLine(item.Name);
                foreach (XmlNode ch in item.ChildNodes)
                {
                    Console.Write("--> ");
                    Console.WriteLine(ch.Name);

                    if(ch.Name == "item")
                    {

                        HabrNews hNews = new HabrNews();

                        foreach (XmlNode news in ch.ChildNodes)
                        {
                            if (news.Name == "title")
                            {
                                hNews.title = news.InnerText;
                            }
                            else if (news.Name == "link")
                            {
                                hNews.lint = news.InnerText;
                            }
                            habrNews.Add(hNews);


                            Console.Write("----------> ");
                            Console.WriteLine(news.Name);

                            Console.WriteLine(news.InnerText); //dostali text 

                        }


                    }


                }


            }



            foreach (var item in habrNews)
            {
                Console.WriteLine(item.title);
                Console.WriteLine(item.lint);
                Console.WriteLine("");
            }


            /* 2. На основании задания 1, сериализовать лист полученных объектов в XML и записать в файл.*/



           // lkbhgvkjaelkv

            // КОНЕЦ ДОМАШНЕЙ РАБОТЫ








            //------------------------------------------------------------------------------------------------//
            return;
            //это основа создания документа
            XmlDocument doc = new XmlDocument(); // sozdaem

            XmlElement root = doc.CreateElement("User"); //XmlDocument generirut elementu

            XmlElement name = doc.CreateElement("Name");
            name.InnerText = "Alfar";

            root.AppendChild(name);

            doc.AppendChild(root);

            doc.Save("UserAlfar.xml");

            //-----------------------------------//

            //1
            XmlAttribute atr = doc.CreateAttribute("IIN");
            atr.InnerText = "123456789789";
            name.Attributes.Append(atr);

            //2
            //name.SetAttribute("IIN", "123456789789");

            root.AppendChild(name);

            doc.Save("UserAlfar.xml");

            //-----------------------------------//

            //SCHITAT


          



        }
    }
}
