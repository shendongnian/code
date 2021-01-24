    public Form1()
            {
                InitializeComponent();
                //read the file
                System.IO.StreamReader file =
                               new System.IO.StreamReader("yourFileName.txt");
    
                //set list view in details mode
                listView1.View = View.Details;
    
                //Set columns in listview
                listView1.Columns.Add("Date Time");
                listView1.Columns.Add("X");
                listView1.Columns.Add("Y");
                listView1.Columns.Add("Z");
                string line = "";
                //read text file line by line.     
                while (( line = file.ReadLine()) != null)
                {
                    var itemMC = new ListViewItem(new[] { line.ToString().Split(';')[0].ToString(), line.ToString().Split(';')[2].ToString(), 
                        line.ToString().Split(';')[4].ToString(), line.ToString().Split(';')[6].ToString() });
                    listView1.Items.Add(itemMC);
    
                }
                file.Close();
            }
