    private void Display(int count)
            {
             
                textBox1.Text = "";
                for (int i = 0; i <= count ; i++)
                {
                    textBox1.Text += ((dataGridView1.Rows[i].Cells[1].Value).ToString()) +  (dataGridView1.Rows[i].Cells[2].Value.ToString()) + Environment.NewLine;
                  
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                try
                {
                    
                    // your code here 
    
                    string CSVFilePathName =Path.GetDirectoryName(Application.ExecutablePath).Replace(@"\bin\Debug", @"\NewFolder1\TEST.csv");
                    string[] Lines = File.ReadAllLines(CSVFilePathName);
                    string[] Fields;
                    Fields = Lines[0].Split(new char[] { ',' });
                    int Cols = Fields.GetLength(0);
                    DataTable dt = new DataTable();
                    //1st row must be column names; force lower case to ensure matching later on.
                    for (int i = 0; i < Cols; i++)
                        dt.Columns.Add(Fields[i].ToLower(), typeof(string));
                    DataRow Row;
                    for (int i = 1; i < Lines.GetLength(0); i++)
                    {
                        Fields = Lines[i].Split(new char[] { ',' });
                        Row = dt.NewRow();
                        for (int f = 0; f < Cols; f++)
                            Row[f] = Fields[f];
                        dt.Rows.Add(Row);
                    }
                    dataGridView1.DataSource = dt;
                   
                    int count = 0;
    
                    if (dataGridView1.RowCount > 0)
                    {
    
                        count = dataGridView1.Rows.Count;
                    }
    
                 
                    buttons  = new Button[count];
                    for (int i = 0; i <count; i++)
                    {
                        buttons[i] = new Button();
                        buttons[i].Name = "buttons_Click" + i.ToString();
                        buttons[i].Text = "Click";
                        buttons[i].Click += new EventHandler(buttons_Click);
                        this.Controls.Add(buttons[i]);
                        buttons[i].Visible = false;
                    }
    
                    buttons[0].Visible = true;
                   // buttons[1].Visible = true;
                    
                }
    
              
                catch (Exception ex)
                {
                    MessageBox.Show("Error is " + ex.ToString());
                    throw;
                }
            }
            private void buttons_Click(object sender, EventArgs e)
            {
                int count = dataGridView1.Rows.Count-1;
                if(c <= count)
                {
    
                    if (buttons[c].Name == "buttons_Click" + c.ToString())
                    {
                        buttons[c].Visible = false;
                        int j = c;
                        Display(j);
                        if (c != count)
                        {
                            
                            c = c + 1;
                            buttons[c].Visible = true;
                        }
                       
                    }
    
                }
                if (c == count)
                {
                    buttons[0].Visible = true;
                }
            }
        }
    }
