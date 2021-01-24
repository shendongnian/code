                if (utility.isNum,(txt_LndLine.Text))
                {
                    epLandline.SetError(txt_LndLine, "Please use unknown Entity!!!");
                  //PANEL COLOR
                  this.panel1.BackColor = System.Drawing.Color.Green;
                  this.panel1.Padding = new System.Windows.Forms.Padding(5);
    
                    return;
                }
    
                else 
                {
                    epLandline.Clear();
                    
                   //PANEL COLOR
                    this.panel1.BackColor = System.Drawing.Color.Red;
                    this.panel1.Padding = new System.Windows.Forms.Padding(5);
    
                    _IsValid = true;    
                } 
