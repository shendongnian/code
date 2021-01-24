            ..........            
            List<string> fileNames;
            public Form1()
            {
                InitializeComponent();
            }
            public void button1_Click(object sender, EventArgs e)
            {
                fileNames = new List<string>();
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                ofd.Multiselect = true;
                ofd.Filter = "XML Files (*.xml)|*.xml";
                foreach (String file in ofd.FileNames)
                {
                    MessageBox.Show(file);
                    fileNames.Add(file); //<- try this instead
                }
            }
            ..................
