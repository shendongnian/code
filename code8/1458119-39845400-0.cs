        private void frmMain_Load(object sender, EventArgs e)
        {
               int userPermittedCount = 4 // You can add user defined permission no : of text box count here;
               int pointX = 30;
               int pointY = 40;
        
               for (int i = 0; i < userPermittedCount; i++)
               {
                  TextBox txtBox = new TextBox();
                  txtBox.Location = new Point(pointX, pointY);
                  this.Controls.Add(txtBox);
                  this.Show();
                  pointY += 20;
                  txtBox.TextChanged += txtAdd_TextChanged;
                }
       }
     private void txtAdd_TextChanged(object sender, EventArgs e)
     {
     }
