        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Xml.Serialization;
        namespace ConsoleApplication11
        {
            class Program
            {
                static void Main(string[] args)
                {
                    string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <abc>
                       <Limits>
                            <Row>
                                <LimitId>101</LimitId>
                                <Max>10000</Max>
                                <Current>0</Current>
                            </Row>
                            <Row>
                                <LimitId>102</LimitId>
                                <Max>6000</Max>
                                <Current>0</Current>
                            </Row>
                            <Row>
                                <LimitId>109</LimitId>
                                <Max>25000</Max>
                                <Current>0</Current>
                            </Row>
                            <Row>
                                <LimitId>200</LimitId>
                                <Max>45000</Max>
                                <Current>0</Current>
                            </Row>
                        </Limits>
                    </abc>";
                    XmlSerializer d = new XmlSerializer(typeof(LimitCollection));
                    LimitCollection deserializedXml = (LimitCollection)d.Deserialize(new StringReader(xml));
                    Console.WriteLine("Iterating all limits:");
                    foreach (Limit lim in deserializedXml.Limits)
                    {
                        Console.WriteLine($"LimitId: {lim.LimitId}, Current: {lim.Current}, Max: {lim.Max}");
                    }
                    Console.WriteLine();
                    Limit particularLimit = deserializedXml.Limits.FirstOrDefault(l => l.LimitId == 109);
                    if (particularLimit != null)
                    {
                        Console.WriteLine($"Particular limit: {particularLimit.LimitId}, Current: {particularLimit.Current}, Max: {particularLimit.Max}");
                    }
                    Console.WriteLine("Press any key to finish...");
                    Console.ReadKey();
                }
            }
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false, ElementName = "abc")]
            public partial class LimitCollection
            {
                private Limit[] limitsField;
                /// <remarks/>
                [System.Xml.Serialization.XmlArrayItemAttribute("Row", IsNullable = false)]
                public Limit[] Limits
                {
                    get
                    {
                        return this.limitsField;
                    }
                    set
                    {
                        this.limitsField = value;
                    }
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class Limit
            {
                private byte limitIdField;
                private ushort maxField;
                private byte currentField;
                /// <remarks/>
                public byte LimitId
                {
                    get
                    {
                        return this.limitIdField;
                    }
                    set
                    {
                        this.limitIdField = value;
                    }
                }
                /// <remarks/>
                public ushort Max
                {
                    get
                    {
                        return this.maxField;
                    }
                    set
                    {
                        this.maxField = value;
                    }
                }
                /// <remarks/>
                public byte Current
                {
                    get
                    {
                        return this.currentField;
                    }
                    set
                    {
                        this.currentField = value;
                    }
                }
            }
        }
