            public class Flasher
            {
                //Fixed
                //InnerException: System.InvalidOperationException
                //Message="For non-array types, you may use the following attributes: XmlAttribute, XmlText, XmlElement, or XmlAnyElement."
                [XmlElement("Item")]
                public List<Item> items;
