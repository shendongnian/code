    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Item> treeMenu = new List<Item>() {
                    new Item() {
                        attributes = new Dictionary<string,string>() {
                            { "id", "43BDF924-5E"},
                            { "text", "System Management"},
                            { "system","010"}
                        },
                        children = new List<Item>() {
                            new Item() {
                                attributes = new Dictionary<string,string>() {
                                    { "id", "36A21901-45"},
                                    { "text","Basic Information"}
                                },
                                children = new List<Item>() {
                                    new Item() {
                                        attributes = new Dictionary<string,string>() {
                                            { "id", "7FA03116-0F"},
                                            { "text", "Info" }
                                        },
                                        children = new List<Item>() {
                                            new Item() {
                                                attributes = new Dictionary<string,string>() {
                                                    { "id", "74713E10-FF"},
                                                    { "code", "AGM-D-1240-01"},
                                                    { "text", "Persons" }
                                                }
                                            }
                                        }
                                    },
                                    new Item() {
                                        attributes = new Dictionary<string,string>() {
                                            { "id", "5373F379-E8"},
                                            { "code", "AGM-D-1260-01"},
                                            { "text", "Stock" }
                                        }
                                    }
                                }
                            }
                        }    
                    },
                    new Item() {
                        attributes = new Dictionary<string,string>() {
                            { "id", "36A21901-45"},
                            { "text", "Google"}
                        },
                        children = new List<Item>() {
                            new Item() {
                                attributes = new Dictionary<string,string>() {
                                    { "id", "7FA03116-0F"},
                                    { "text", "sites"}
                                },
                                children = new List<Item>() {
                                    new Item() {
                                        attributes = new Dictionary<string,string>() {
                                            { "id", "74876E10-FF"},
                                            { "code", "MM-D-1240-01"},
                                            { "text","Serch"}
                                        }
                                    },
                                    new Item() {
                                        attributes = new Dictionary<string,string>() {
                                            { "id", "0981F379-E8"},
                                            {"code", "MM-D-1260-01"},
                                            { "text","Gmail"}
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
                XElement menu = new XElement("menu");
                foreach (Item item in treeMenu)
                {
                    XElement newChild = new XElement("item");
                    menu.Add(newChild);
                    Item.CreateXmlElement(newChild, item);
                }
            }
        }
        public class Item
        {
            public Dictionary<string, string> attributes { get; set; }
            public List<Item> children { get; set;}
            public static void CreateXmlElement(XElement parentElement, Item parentItem)
            {
                foreach (KeyValuePair<string,string> pair in parentItem.attributes.AsEnumerable())
                {
                    parentElement.Add(new XAttribute(pair.Key, pair.Value));
                }
                if (parentItem.children != null)
                {
                    foreach (Item item in parentItem.children)
                    {
                        XElement newChild = new XElement("item");
                        parentElement.Add(newChild);
                        CreateXmlElement(newChild, item);
                    }
                }
            }
        }
    }
