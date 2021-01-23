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
                List<Item> items = new List<Item>() {
                    new Item() {
                        SKU = "7Z-BRPA-K79A",
                        PROD_NAME = "Test One",
                        Description = "ExcelMark 5-Line Large Return Address Stamp - Custom Self Inking Rubber Stamp",
                        Attributes = "Custom Text Line 1 Text: This book was donated to CAEO Font: Arial" +
                                " Custom Text Line 2 Text: In tribute to & memory of Font: Arial",
                        Quantity = 1,
                        UnitPrice =  "$9.99",
                        InkColor = "Red"
                    },
                    new Item() {
                        SKU = "42A1848",
                        PROD_NAME = "Test Two",
                        Description = "Self Inking Rubber Stamp with up To 4 Lines of Custom Text",
                        Attributes = "Custom Text Line 1 Text: This book was donated to CAEO Font: Arial" +
                               " Custom Text Line 2 Text: In tribute to & memory of Font: Arial",
                        Quantity = 1,
                        UnitPrice = "$8.99",
                        InkColor = "Blue"
                    }
                };
                XElement xItems = new XElement("Items");
                foreach (Item item in items)
                {
                    XElement xItem = new XElement("Item", new object[] {
                        new XElement("SKU", item.SKU),
                        new XElement("PROD_NAME",  new XCData(item.PROD_NAME)),
                        new XElement("Description", new XCData(item.Description)),
                        new XElement("Attribute", new XCData(item.Attributes)),
                        new XElement("Quantity", item.Quantity),
                        new XElement("UnitPrice", new XCData(item.UnitPrice)),
                        new XElement("InkColor", item.InkColor)
                    });
                    xItems.Add(xItem);
                }
            }
        }
        public class Item
        {
            public string SKU { get; set; }
            public string PROD_NAME { get; set; }
            public string Description { get; set; }
            public string Attributes { get; set; }
            public int Quantity { get; set; }
            public string UnitPrice { get; set; }
            public string InkColor { get; set; }
        }
    }
    //<Items>
    //  <Item>
    //    <SKU>7Z-BRPA-K79A</SKU>
    //    <PROD_NAME><![CDATA[Test One]]></PROD_NAME>
    //    <Description><![CDATA[ExcelMark 5-Line Large Return Address Stamp - Custom Self Inking Rubber Stamp]]></Description>
    //    <Attributes><![CDATA[Custom Text Line 1 Text: This book was donated to CAEO Font: Arial
    //                Custom Text Line 2 Text: In tribute to & memory of Font: Arial]]></Attributes>
    //    <Quantity>1</Quantity>
    //    <UnitPrice><![CDATA[$9.99]]></UnitPrice>
    //    <InkColor>Red</InkColor>
    //  </Item>
    //  <Item>
    //    <SKU>42A1848</SKU>
    //    <PROD_NAME><![CDATA[Test Two]]></PROD_NAME>
    //    <Description><![CDATA[Self Inking Rubber Stamp with up To 4 Lines of Custom Text]]></Description>
    //    <Attributes><![CDATA[Custom Text Line 1 Text: This book was donated to CAEO Font: Arial
    //                Custom Text Line 2 Text: In tribute to & memory of Font: Arial]]></Attributes>
    //    <Quantity>1</Quantity>
    //    <UnitPrice><![CDATA[$8.99]]></UnitPrice>
    //    <InkColor>Blue</InkColor>
    //  </Item>
    //</Items>
