    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    class Program
    {
        static void Main(string[] args)
        {
            Transaction transaction = new Transaction();
            transaction.Function_Type = "LINE_ITEM";
            transaction.LineItems = new List<Merchandise>();
            transaction.LineItems.Add(new Merchandise() { UnitPrice = "5.00" });
            XmlSerializer serializer = new XmlSerializer(typeof(Transaction));
            serializer.Serialize(Console.Out, transaction);
            Console.Read();
        }
    }
    [XmlRoot("TRANSACTION")]
    public class Transaction
    {
        [XmlElement("FUNCTION_TYPE")]
        public string Function_Type { get; set; }
        [XmlArray("LINE_ITEMS")]
        [XmlArrayItem("MERCHANDISE")]
        public List<Merchandise> LineItems { get; set; }
    }
    [XmlRoot("MERCHANDISE")]
    public class Merchandise
    {
        [XmlElement("UNIT_PRICE")]
        public string UnitPrice { get; set; }
    }
