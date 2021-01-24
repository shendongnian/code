    This is used for the color of the grid view data rows.
    
       public System.Drawing.Color GetColor(string butColor)
            {
                System.Drawing.Color cr = new System.Drawing.Color();
                if (butColor == "1")
                {
                    cr = System.Drawing.Color.Green;
                }
                else if (butColor == "0")
                {
                    cr = System.Drawing.Color.Red;
                }
                return cr;
            }
    
     This is used for the status:
    
       protected string GetStatus(string butStatus)
            {
                if (butStatus == "1")
                {
                    butStatus = "ACTIVE";
                }
                else if (butStatus == "0")
                {
                    butStatus = "DEACTIVE";
                }
                return butStatus;
            }
