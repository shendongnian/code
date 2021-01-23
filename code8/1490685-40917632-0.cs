    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication29
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Design> designTable = new List<Design>() {
                    new Design() { DesignId = 1,  DesignName = "A"},
                    new Design() { DesignId = 2,  DesignName = "B"},
                    new Design() { DesignId = 3,  DesignName = "C"}
                };
                List<Attribute> attributeTable = new List<Attribute>() {
                    new Attribute() { AttributeId = 1, AttributeName = "Light"},
                    new Attribute() { AttributeId = 2, AttributeName = "Dark"},
                    new Attribute() { AttributeId = 3, AttributeName = "Demo"}
                };
                List<DesignAttribute> designAttributeTable = new List<DesignAttribute>() {
                    new DesignAttribute() { DesignAttributeId = 1, DesignId = 1, AttributeId = 1},
                    new DesignAttribute() { DesignAttributeId = 2, DesignId = 1, AttributeId = 3},
                    new DesignAttribute() { DesignAttributeId = 3, DesignId = 2, AttributeId = 2},
                    new DesignAttribute() { DesignAttributeId = 4, DesignId = 3, AttributeId = 1}
                };
                var results = (from dattbl in designAttributeTable
                               join dttbl in designTable on dattbl.DesignId equals dttbl.DesignId
                               join attbl in attributeTable on dattbl.AttributeId equals attbl.AttributeId
                               select new { designName = dttbl.DesignName, attributeName = attbl.AttributeName }).ToList();
     
            }
     
        }
        public class Design
        {
            public int DesignId { get; set; }
            public string DesignName { get; set; }
            public virtual List<DesignAttribute> DesignAttributes { get; set; }
        }
        public class Attribute
        {
            public int AttributeId { get; set; }
            public string AttributeName { get; set; }
        }
        public class DesignAttribute
        {
            public int DesignAttributeId { get; set; }
            public int DesignId { get; set; }
            public int AttributeId { get; set; }
        }
        
    }
