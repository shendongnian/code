    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string stringtest = "<Root>" +
                    "<ProcessingUnit>Lifestyle</ProcessingUnit>" +
                    "<ProcessingData>" +
                        "<ProcessType>Product</ProcessType>" +
                        "<ProcessAction>Create</ProcessAction>" +
                        "<Id>7</Id>" +
                    "</ProcessingData>" +
                    "</Root>";
                XmlSerializer _serializer = new XmlSerializer(typeof(XmlRoot));
                using (var reader = new StringReader(stringtest))
                {
                    XmlRoot tradeData = (XmlRoot)_serializer.Deserialize(reader);
                }
     
     
            }
        }
        [XmlRoot("Root")]
        public class XmlRoot
        {
            [XmlElement("ProcessingUnit")]
            public ProcessingUnit ProcessingUnit { get; set; }
            [XmlElement("ProcessingData")]
            public ProcessingData ProcessingData { get; set; }
        }
        [XmlRoot("ProcessingData")]
        public class ProcessingData
        {
            [XmlElement("ProcessType")]
            public ProcessType ProcessType { get; set; }
            [XmlElement("ProcessAction")]
            public ProcessAction ProcessAction { get; set; }
            [XmlElement("Id")]
            public int Id { get; set; }
        }
        [XmlRoot("ProcessingUnit")]
        public class ProcessingUnit
        {
            [XmlText] 
            public string text { get; set; }
        }
        [XmlRoot("ProcessType")]
        public class ProcessType
        {
            [XmlText]
            public string text { get; set; }
        }
        [XmlRoot("ProcessAction")]
        public class ProcessAction
        {
            [XmlText]
            public string text { get; set; }
        }
    }
