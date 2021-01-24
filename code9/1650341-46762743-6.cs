    private readonly XmlSerializer xs;
    private AddressBook ls;
    private int _counter = 0;
    
    public FormAddNew2()
    {
        InitializeComponent();
    
        ls = new AddressBook();
        xs = new XmlSerializer(typeof(AddressBook));
    }
    
    private void buttonCreate_Click(object sender, EventArgs e)
    {
        var addressBookContact2 = new Contact
        {
            Id = ++_counter,
            Name = textBoxName.Text,
            Age = textBoxAge.Text,
            Gender = textBoxGender.Text
        };
    
        ls.Contacts.Add(addressBookContact2);
    
        dataGridView1.DataSource = null; // strangly u need this
        dataGridView1.DataSource = ls.Contacts;
    }
    
    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = @"C:\";
        saveFileDialog.RestoreDirectory = true;
        saveFileDialog.Title = "Select save location file name";
        saveFileDialog.Filter = "XML-File | *.xml";
        if(saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            using(var writer = new StreamWriter(saveFileDialog.FileName))
            {
                xs.Serialize(writer, ls);
                MessageBox.Show(saveFileDialog.FileName);
            }
        }
    }
    
    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "xml file | *.xml";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;
    
        if(openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using (var reader = new StreamReader(@openFileDialog.FileName))
                {
                    ls = (AddressBook) xs.Deserialize(reader);
                    _counter = 0;
                    dataGridView1.DataSource = ls.Contacts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR");
            }
        }
    }
