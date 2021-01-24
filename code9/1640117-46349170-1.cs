        private void cargaComboLenguajes()
        {
           if(session["cmbIdioma"]!="")
    {
       cmbIdioma.SelectedValue = session["cmbIdioma"].ToString();
                
    }
    
    else
    {
    cmbIdioma.SelectedValue ="en-us";
      session["cmbIdioma"]="en-us";
    }
           
        }
        protected void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = cmbIdioma.SelectedValue;
    
            if (!string.IsNullOrEmpty(language))
            {
                   
                 session["cmbIdioma"].ToString()=cmbIdioma.SelectedValue.ToString();
                 Response.Redirect("Default.aspx?lenguaje="+session["cmbIdioma"].ToString());
                
            }
        }
    
    
    
    
