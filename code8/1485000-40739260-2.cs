    protected void MakeButtons()
    {
        rowNum = UpDownRow.Text;
        int nr = Int16.Parse(rowNum);    
        colNum = UpDownColumn.Text;
        int nc = Int16.Parse(colNum);
        int btnHeight = panel1.Height / Int16.Parse(rowNum);
        int btnWidth = panel1.Width / Int16.Parse(colNum);
        for (int row = 0; row < nr; row++)
        {
            for (int column = 0; column < nc; column++)
            {
                Button btnNew = new Button();
                btnNew.Name = "btn_" + column + "_" + row;
                btnNew.Height = btnHeight-5;
                btnNew.Width = btnWidth-5;
                btnNew.Font = new Font("Arial", 20);
               // btnNew.Text = theSymbol;
                btnNew.Image = Properties.Resources.backg;
                btnNew.Visible = true;
               // int CenterPoint = panel1.Width / 3;
                btnNew.Location = new Point(10 + (column* btnNew.Width), 10 + (row* btnNew.Height));
                // hook this button to a click event
                btnNew.Click += new EventHandler(WhoClicked);
                //Controls.Add(btnNew);
                panel1.Controls.Add(btnNew);
            }
        }
    }
    private void WhoClicked(object sender, EventArgs e)
    {
    
        picSymbol = Properties.Resources.Player;
    
        foreach (var control in this.panel1.Controls)
        {
            if (control is Button)
            {
                control.Enabled = false;
            }
        }
    } 
