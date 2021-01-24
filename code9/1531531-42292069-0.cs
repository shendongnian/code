    int c = 0; // for uinque txtDynamic text creation 
    private void button1_Click(object sender, EventArgs e)
    {
          TextBox txtDynamic = this.Controls.Find("txtDynamic" + c, true)[0] as TextBox; // find lastly added txtDynamic 
            
          TextBox txtRun = new TextBox();
          txtRun.Name = "txtDynamic" + ++c;
          txtRun.Size = new System.Drawing.Size(100, 20);
          txtRun.Location = new Point(txtDynamic.Location.X, txtDynamic.Location.Y + 35); // X axis will be same y will increase with count 35
                
              
          foreach (Control item in this.Controls)
          {
               if (item.Location.Y >= txtRun.Location.Y){ // if there is an item that has greater Y location
                   item.Location = new Point(item.Location.X, txtRun.Location.Y + 35); // It should increase its value as 35 too.
               }
               this.Controls.Add(txtRun);
     
          }
    }
