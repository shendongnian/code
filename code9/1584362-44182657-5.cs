    public void Button1_Click(object sender, EventArgs e)
    {
         int check = 0;
         foreach (Control control in TabelaPrincipal.Controls)
         {
             check = SearchControl(control, check);
         }
         
         //Here Check is OK (It has the number of the checkboxes that are checked in the interface)
         Response.Write(check);
    }
    public int SearchControl(Control control, int check)
        {
            if (control != null && control.Controls !=null && control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {
                    check = SearchControl(c, check);
                }                
            }
            else
            {
                if ((control is CheckBox) && ((CheckBox)control).Checked)
                {
                    check += 1;
                }
            }
           
            return check;
            
        }
