     private void materialFlatButton3_Click_1(object sender, EventArgs e) 
    //button used to load the DLL into the ListBox.
                {
                    OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
                    OpenFileDialog1.Multiselect = true;
                    OpenFileDialog1.Filter = "DLL Files|*.dll";
                    OpenFileDialog1.Title = "Select a Dll File";
                    if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // put the selected result in the global variable
                        // ~~Using Dictionary instead of list~~
                        fullFileName = new Dictionary<string, string>(OpenFileDialog1.FileNames);
                        // Populate Listbox from dictionary.    
                        listBox2.Datasource = fullFileName.ToList();
                        listBox2.DisplayMember = "Value";
                        listBox2.ValueMember = "Key";    
                    }
                }
