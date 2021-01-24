    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            
            static void Main(string[] args)
            {
                Layout layout = new Layout(FILENAME);
            }
        }
        public class Layout
        {
            public string tablename { get; set; }
            public List<Field> fields { get; set; }
            public Layout layout { get; set; }
            public Dictionary<string, Item> dict = new Dictionary<string, Item>();
            public Layout() { }
            public Layout(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement xLayout = doc.Descendants().Where(x => x.Name.LocalName == "Layout").FirstOrDefault();
                XNamespace ns = xLayout.GetNamespaceOfPrefix("ns");
                foreach (XElement item in doc.Descendants(ns + "Item"))
                {
                    int catalogid = (int)item.Attribute("catalogid");
                    int id = (int)item.Attribute("id");
                    foreach(XElement fieldValue in item.Elements(ns + "FieldValue"))
                    {
                        string uid = (string)fieldValue.Attribute("uid");
                        uid = uid.Replace("{", "");
                        uid = uid.Replace("}", "");
                        string innertext = (string)fieldValue;
                        if (!dict.ContainsKey(uid))
                        {
                            Item newItem = new Item() { catalogidId = new List<KeyValuePair<int, int>>() {new KeyValuePair<int, int>(catalogid, id)}, innertext = innertext, uid = uid };
                            dict.Add(uid, newItem);
                        }
                        else
                        {
                           dict[uid].catalogidId.Add(new KeyValuePair<int, int>(catalogid, id));
                        }
                    }
                }
                layout = new Layout();
                RecursiveParse(ns, xLayout, layout);
            }
            public void RecursiveParse(XNamespace ns, XElement parent, Layout layout)
            {
                layout.tablename = (string)parent.Attribute("tableName");
                foreach(XElement xField in parent.Element(ns + "Fields").Elements(ns + "Field"))
                {
                    if (layout.fields == null) layout.fields = new List<Field>();
                    Field newField = new Field();
                    layout.fields.Add(newField);
                    newField.uid = (string)xField.Attribute("uid");
                    newField.uid = newField.uid.Replace("{", "");
                    newField.uid = newField.uid.Replace("}", "");
                    newField._type = (int)xField.Attribute("type");
                    newField.value = (int)xField.Attribute("valueInterpretation");
                    newField.name = (string)xField.Element(ns + "Name");
                    if (dict.ContainsKey(newField.uid))
                    {
                        newField.items = dict[newField.uid];
                    }
                    if (xField.Element(ns + "Layout") != null)
                    {
                        Layout newLayout = new Layout();
                        newField.layout = newLayout;
                        RecursiveParse(ns, xField.Element(ns + "Layout"), newLayout);
                    }
                }
            }
            public class Field
            {
                public string uid { get; set; }
                public int _type { get; set; }
                public int value { get; set; }
                public string name { get; set; }
                public Layout layout { get; set; }
                public Item items { get; set; }
            }
            public class Item
            {
                // catalog id and id
                public List<KeyValuePair<int, int>> catalogidId { get; set; }
                public string uid { get; set; }
                public string innertext { get; set; }
            }
        }
    }
