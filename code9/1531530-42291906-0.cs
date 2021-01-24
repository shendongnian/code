    private void button1_Click(object sender, EventArgs e)
    {
        TextBox txtRun = new TextBox();
        txtRun.Name = "txtDynamic" + c++;
        txtRun.Location = new System.Drawing.Point(90, 74 + (20 * c));
        this.Controls.Add(txtRun);
        //removed some code for brevity
        //1st solution
        foreach(Control item in this.Controls)
        {
            //there can be some other condition
            //based on e.g. name of TB
            //or if the type is GroupBox with some name
            if(item.Location.Y >= txtRun.Location.Y)
               item.Location.Y = item.Location.Y + 25; 
        }
    }
