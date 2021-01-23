        {
            
            if (cbunderline.Checked == true)
            {               lbltext.Font = new Font(lbltext.Font.Name, lbltext.Font.Size, lbltext.Font.Style | FontStyle.Underline);
			}
            
            if (cbitalic.Checked ==true )
            {
                lbltext.Font = new Font(lbltext.Font.Name, lbltext.Font.Size, lbltext.Font.Style | FontStyle.Italic);
            }
         
            if
                (cbbold.Checked==true)
            {
                lbltext.Font = new Font(lbltext.Font.Name, lbltext.Font.Size, lbltext.Font.Style | FontStyle.Bold);
            }
           
        }
