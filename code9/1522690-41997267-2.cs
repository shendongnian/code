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
    <env:Envelope xmlns:env=""w3.org/2003/05/soap-envelope"" xmlns:m0=""schemas/type.xsd"" xmlns:m1=""schemas/app.xsd"">
        <env:Body>
            <m1:GetLimitsRes > 
                <m1:Response Response=""1""> 
                    <m0:Limits> 
                        <m0:Row> 
                            <m0:LimitId>100</m0:LimitId> 
                            <m0:Max>10000</m0:Max> 
                            <m0:Current>0</m0:Current> 
                        </m0:Row> 
                        <m0:Row> 
                            <m0:LimitId>101</m0:LimitId> 
                            <m0:Max>10000</m0:Max> 
                            <m0:Current>0</m0:Current> 
                        </m0:Row> 
                    </m0:Limits> 
                </m1:Response>
            </m1:GetLimitsRes>
        </env:Body> 
    </env:Envelope>";
                XmlSerializer d = new XmlSerializer(typeof(Envelope));
                Envelope e = (Envelope)d.Deserialize(new StringReader(xml));
                Console.WriteLine("Iterating all limits:");
                foreach (var lim in e.Body.GetLimitsRes.Response.Limits)
                {
                    Console.WriteLine($"LimitId: {lim.LimitId}, Current: {lim.Current}, Max: {lim.Max}");
                }
                Console.WriteLine();
                LimitsRow particularLimit = e.Body.GetLimitsRes.Response.Limits.FirstOrDefault(l => l.LimitId == 101);
                if (particularLimit != null)
                {
                    Console.WriteLine($"Particular limit: {particularLimit.LimitId}, Current: {particularLimit.Current}, Max: {particularLimit.Max}");
                }
                Console.WriteLine("Press any key to finish...");
                Console.ReadKey();
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "w3.org/2003/05/soap-envelope")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "w3.org/2003/05/soap-envelope", IsNullable = false)]
        public partial class Envelope
        {
            private EnvelopeBody bodyField;
            /// <remarks/>
            public EnvelopeBody Body
            {
                get
                {
                    return this.bodyField;
                }
                set
                {
                    this.bodyField = value;
                }
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "w3.org/2003/05/soap-envelope")]
        public partial class EnvelopeBody
        {
            private GetLimitsRes getLimitsResField;
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "schemas/app.xsd")]
            public GetLimitsRes GetLimitsRes
            {
                get
                {
                    return this.getLimitsResField;
                }
                set
                {
                    this.getLimitsResField = value;
                }
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "schemas/app.xsd")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "schemas/app.xsd", IsNullable = false)]
        public partial class GetLimitsRes
        {
            private GetLimitsResResponse responseField;
            /// <remarks/>
            public GetLimitsResResponse Response
            {
                get
                {
                    return this.responseField;
                }
                set
                {
                    this.responseField = value;
                }
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "schemas/app.xsd")]
        public partial class GetLimitsResResponse
        {
            private LimitsRow[] limitsField;
            private byte responseField;
            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Namespace = "schemas/type.xsd")]
            [System.Xml.Serialization.XmlArrayItemAttribute("Row", IsNullable = false)]
            public LimitsRow[] Limits
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
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Response
            {
                get
                {
                    return this.responseField;
                }
                set
                {
                    this.responseField = value;
                }
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "schemas/type.xsd")]
        public partial class LimitsRow
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
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "schemas/type.xsd")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "schemas/type.xsd", IsNullable = false)]
        public partial class Limits
        {
            private LimitsRow[] rowField;
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Row")]
            public LimitsRow[] Row
            {
                get
                {
                    return this.rowField;
                }
                set
                {
                    this.rowField = value;
                }
            }
        }
    }
