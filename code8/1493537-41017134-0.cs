    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    namespace Test
    {
    public class Book
    {
        public string Href { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Characters { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str="<div id='title'><li class='Main'><h3><a href='www.harrypotter.com'>Harry Potter</a></h3><div>Harry James Potter is the title character of J. K. Rowling's Harry Potter series. </div>";
            str += "<ul><li>Harry Potter</li><li>Hermione Granger</li><li>Ron Weasley</li></ul></li><li class='Main'><h3><a href='www.littleprince.com'>Little Prince</a></h3><div>A little girl lives in a very grown-up world with her mother, who tries to prepare her for it.  </div></li></div>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(str);
            XmlNodeList xnList= doc.SelectNodes("//*[@id=\"title\"]//li[@class=\"Main\"]");
            List<Book> BookList=new List<Book>();
            for (int i = 0; i < xnList.Count; i++)
            {
                XmlNode TitleNode = xnList[i].SelectSingleNode("h3");
                XmlNode DescNode = xnList[i].SelectSingleNode("div");
                XmlNode AuthorNode = xnList[i].SelectSingleNode("ul");
                Book list = new Book();
                if(TitleNode!=null)
                    list.Title=TitleNode.InnerText;
                else
                    list.Title="";
                if (DescNode != null)
                    list.Author = DescNode.InnerText;
                else
                    list.Author = string.Empty;
                if (AuthorNode != null)
                    list.Characters = AuthorNode.InnerText;
                else
                    list.Characters = string.Empty;
                if (TitleNode != null && TitleNode.ChildNodes.Count>0)
                {
                    XmlNode HrefNode = TitleNode.ChildNodes[0];
                    if (HrefNode != null && HrefNode.Attributes.Count > 0 && HrefNode.Attributes["href"] != null)
                        list.Href = HrefNode.Attributes["href"].Value;
                    else
                        list.Href = string.Empty;
                }
                else
                {
                    list.Href = string.Empty;
                }
                BookList.Add(list);
            }
        }
    }
    }
