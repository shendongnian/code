    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    static class Program
    {
        static void Main()
        {
            var xml = @"<AccountInfo ID=""accid1"" Currency=""EUR"">
      <AccountNumber international=""false"">10000</AccountNumber>
      <AccountNumber international=""true"">DE10000</AccountNumber>
      <BankCode international=""false"">22222</BankCode>
      <BankCode international=""true"">BC22222</BankCode>
      <AccountHolder>Some Dude</AccountHolder>
    </AccountInfo>";
            var ser = new XmlSerializer(typeof(AccountInfo));
            var obj = ser.Deserialize(new StringReader(xml));
    
            // ...
        }
    }
    
    public class AccountInfo
    {
        [XmlElement]
        public List<BankAccount> AccountNumber { get; } = new List<BankAccount>();
        [XmlElement]
        public List<BankAccount> BankCode { get; } = new List<BankAccount>();
    
        public string AccountHolder { get; set; }
        [XmlAttribute("ID")]
        public string Id {get;set;}
        [XmlAttribute]
        public string Currency {get;set;}
    }
    public class BankAccount
    {
        [XmlAttribute("international")]
        public bool International { get; set; }
        [XmlText]
        public string Number { get; set; }
    }
