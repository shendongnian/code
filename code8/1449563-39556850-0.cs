    // return is changed from void to TextBox:
    public static TextBox makeTextBox(Panel pnlMain, int offsetTop, int offsetRight, string strName = "")
    {
        TextBox txt = new TextBox();
        txt.Name = strName;
        txt.Parent = pnlMain;
        txt.AutoSize = true;
        txt.Width = (pnlMain.Width - 9 * defdis) / 3; //defdis is a public int and means default distance
        txt.Location = new Point(pnlMain.Width - txt.Width - defdis - offsetRight - 3, offsetTop + defdis);
        
        // return the textbox you created:
        return txt;
    }
