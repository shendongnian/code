      //create xml file and paste the following code:
      <Data>
        <Names>
           <Name> Jhon </Name>
           <Name> Foo </Name>
           <Name> Dog </Name> 
        </Names>
      </Data>
        private XDocument _doc;
        // path to created file.
        private string _filename = "C:\\temp\\test.xml";
        public Form1()
        {
            InitializeComponent();
            // load file into XDocument
            _doc = XDocument.Load(_filename);
        }
        // load name from xml into textbox when application starts
        private void Form1_Load(object sender, EventArgs e)
        {
            // Name[1] first child of Names, Name[2] second etc 
            XElement node = _doc.XPathSelectElement("Data/Names/Name[1]");
            textBox1.Text = node.Value;
        }
        // Create element and appeden it to Names element 
        private void button1_Click(object sender, EventArgs e)
        {
            // Append node
            _doc.XPathSelectElement("Data/Names").Add(new XElement("Name", textBox1.Text));
            // Save the file
            _doc.Save(_filename);
        }
