    public partial class Form1 : Form
    {
        public Form1()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\test.xml");
            var node = doc.SelectSingleNode("/tab/message");
            // Gets "Hello World"
            var message = node.InnerText;
            // you can do whatever with the message now...
        }
    }
