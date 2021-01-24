    private void BtnAddButton_Click(object sender, EventArgs e)
    {           
         MetroFramework.Controls.MetroTextBox Textbox2 = new MetroFramework.Controls.MetroTextBox
         {
             Location = new System.Drawing.Point(98, lblHandy.Location.Y - 30),
             Name = "Textbox2",
             Size = new System.Drawing.Size(75, 23),
             TabIndex = 1,
             ID = "text2"
         };
         this.Controls.Add(Textbox2);
    }
