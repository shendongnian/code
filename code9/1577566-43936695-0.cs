    foreach (object obj in Lbls)
    {
        Label LblsAdd = new Label();
        LblsAdd.AutoSize = true;
        LblsAdd.Text = obj.ToString();
        X = X + 50;  // write a new value into the variable X
        LblsAdd.Left = X;
        LblsAdd.Top = Y;
        LblsAdd.Size = new System.Drawing.Size(30, 15); 
        MyTabPage.Controls.Add(LblsAdd);
    }
