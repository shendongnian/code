    private void addComboBox(){
       ComboBox cB = new ComboBox();
       ArrayList items = new ArrayList();
       cB.Items.Add(new items("Select a File",""));
       cB.Items.Add(new items("myFile.txt",@"c:\myfile.txt"));
       cB.Items.Add(new items("yourFile.csv",@"d:\oldFiles\yourfile.csv"));
       cB.SelectedIndex=0;
       cB.AutoPostBack = true;
       cB.SelectedIndexChanged = process_CB_File;
       this.Controls.Add(cB);
    }
    private void process_CB_File(object sender, EventArgs e){
        ComboBox c = sender as ComboBox;
        if(c.SelectedIndex>0){
            string fileURL = c.SelectedValue.ToString();
            //process file
        }
    }  
