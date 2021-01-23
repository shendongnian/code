    //Get text inside text box
    string textInsideTheTextbox = textBox1.Text;
    //Dummy number
    int dnum;
    //Try parse
    if (int.TryParse(textInsideTheTextbox, out dnum) == false) { /*Can not parse*/return; }
    //Check duplicate
    bool isDuplicate = listBox1.Items.OfType<int>().Contains(dnum);
    //Show message box
    if(isDuplicate) { MessageBox.Show("This number already exists!"); return; }
    if(this.index < MAX_ITEMS) {
        //......
        //......
        //STUFF
        listBox1.Items.Add(dnum);
        index++;
        //......
        //......
        //STUFF
    }
