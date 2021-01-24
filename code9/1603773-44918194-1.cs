    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace DeserializeXMLConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlString = File.ReadAllText(@"D:\My Apps\Console Applications\DeserializeXMLConsoleApp\DeserializeXMLConsoleApp\XMLFile1.xml");
                var serializer = new XmlSerializer(typeof(SettlementLineItem));
                using (var reader = new StringReader(xmlString))
                {
                    var finalResult =  (SettlementLineItem)serializer.Deserialize(reader);
                }
                Console.Read();
            }
        }
    
        [XmlRoot(ElementName = "adjustmentReason")]
        public class AdjustmentReason
        {
            [XmlElement(ElementName = "messageReason")]
            public string MessageReason { get; set; }
            [XmlElement(ElementName = "sourceCode")]
            public string SourceCode { get; set; }
        }
    
        [XmlRoot(ElementName = "alternateAdjustmentReference")]
        public class AlternateAdjustmentReference
        {
            [XmlElement(ElementName = "alternateAdjustmentReferenceType")]
            public string AlternateAdjustmentReferenceType { get; set; }
            [XmlElement(ElementName = "identification")]
            public string Identification { get; set; }
        }
    
        [XmlRoot(ElementName = "adjustmentAndDiscount")]
        public class AdjustmentAndDiscount
        {
            [XmlElement(ElementName = "amount")]
            public string Amount { get; set; }
            [XmlElement(ElementName = "adjustmentReason")]
            public AdjustmentReason AdjustmentReason { get; set; }
            [XmlElement(ElementName = "alternateAdjustmentReference")]
            public AlternateAdjustmentReference AlternateAdjustmentReference { get; set; }
        }
    
        [XmlRoot(ElementName = "contentOwner")]
        public class ContentOwner
        {
            [XmlElement(ElementName = "gln")]
            public string Gln { get; set; }
        }
    
        [XmlRoot(ElementName = "invoice")]
        public class Invoice
        {
            [XmlElement(ElementName = "uniqueCreatorIdentification")]
            public string UniqueCreatorIdentification { get; set; }
            [XmlElement(ElementName = "contentOwner")]
            public ContentOwner ContentOwner { get; set; }
            [XmlElement(ElementName = "invoiceType")]
            public string InvoiceType { get; set; }
            [XmlAttribute(AttributeName = "creationDateTime")]
            public string CreationDateTime { get; set; }
        }
    
        [XmlRoot(ElementName = "partyIdentification")]
        public class PartyIdentification
        {
            [XmlElement(ElementName = "gln")]
            public string Gln { get; set; }
        }
    
        [XmlRoot(ElementName = "settlementEntity")]
        public class SettlementEntity
        {
            [XmlElement(ElementName = "partyIdentification")]
            public PartyIdentification PartyIdentification { get; set; }
            [XmlAttribute(AttributeName = "entityType")]
            public string EntityType { get; set; }
        }
    
        [XmlRoot(ElementName = "settlementLineItem")]
        public class SettlementLineItem
        {
            [XmlElement(ElementName = "amountPaid")]
            public string AmountPaid { get; set; }
            [XmlElement(ElementName = "originalAmount")]
            public string OriginalAmount { get; set; }
            [XmlElement(ElementName = "adjustmentAndDiscount")]
            public List<AdjustmentAndDiscount> AdjustmentAndDiscount { get; set; }
            [XmlElement(ElementName = "invoice")]
            public Invoice Invoice { get; set; }
            [XmlElement(ElementName = "settlementEntity")]
            public SettlementEntity SettlementEntity { get; set; }
            [XmlAttribute(AttributeName = "number")]
            public string Number { get; set; }
        }
    }
