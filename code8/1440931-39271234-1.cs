    private void initializeComboBoxes()
        {
            ComboBox c = new ComboBox();
            c.Name = "cbx_One";
            c.Items.Add("Select a File");
            foreach(string direc in System.IO.Directory.GetDirectories(@"PathToYourFiles"))
            {
                c.Items.Add(direc);
            }
            c.SelectedIndex = 0;
            c.SelectedIndexChanged += loadComboBox2;
            Controls.Add(c);
            ComboBox c1 = new ComboBox();
            c1.Name = "cbx_Two";
            c1.Items.Add("Waiting for file selection");
            c1.SelectedIndex = 0;
            c1.SelectedIndexChanged += loadFile;
            Controls.Add(c1);
            areComboBoxesUpdating = false;
        }
        bool areComboBoxesUpdating = true;
        protected void loadComboBox2(object sender, EventArgs e)
        {
            if (!areComboBoxesUpdating)
            {
                ComboBox c1 = sender as ComboBox;
                ComboBox c2 = Controls.Find("cbx_Two", true)[0] as ComboBox;
                c2.Items.Clear();
                if (c1.SelectedIndex == 0)
                {
                    c2.Items.Add("Waiting for file selection");
                }
                else
                {
                    c2.Items.Add("Please select a file");
                    //assuming c1 is the list of directories
                    foreach (string file in System.IO.Directory.GetFiles(c1.SelectedItem.ToString()))
                    {
                        c2.Items.Add(Path.GetFileName(c1.SelectedItem.ToString()));
                    }
                }
                areComboBoxesUpdating = true;
                c2.SelectedIndex = 0;
                areComboBoxesUpdating = false;
            }
        }
        protected void loadFile(object sender, EventArgs e)
        {
            //a selection has been made from the second box - you have directory in box1 and filename in box2
            ComboBox c = sender as ComboBox;
            if (c.SelectedIndex > 0)
            {
                string directory = ((ComboBox)Controls.Find("cbx_One", true)[0]).SelectedItem.ToString();
                string file = c.SelectedItem.ToString();
                //do something
            }
        }
