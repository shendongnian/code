    CheckBox chkBox = new CheckBox();
    chkBox.Location = new System.Drawing.Point(550, y2);
    chkBox.Name = "CheckBox" + optno.ToString();
    chkBox.Font = new Font("Arial", 10, FontStyle.Bold);
    chkBox.Click += new System.EventHandler(this.CheckBox_CheckedChanged);
