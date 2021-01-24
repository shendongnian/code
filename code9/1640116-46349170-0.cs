    private void cargaComboLenguajes()
    {
        String lenguage = Request.QueryString["lenguaje"] == null ? "" : Request.QueryString["lenguaje"];
        if (lenguage == "en")
        {
            cmbIdioma.SelectedValue = "en-us";
            session["cmbIdioma"]="en";
        }
        else
        {
            cmbIdioma.SelectedValue = "es-mx";
            session["cmbIdioma"]="es";
        }            
    }
    protected void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
    {
        string language = cmbIdioma.SelectedValue;
        if (!string.IsNullOrEmpty(language))
        {
            if (session["cmbIdioma"].ToString()="en")
            {
                Response.Redirect("Default.aspx?lenguaje=en");
            }
            else
            {
                Response.Redirect("Default.aspx?lenguaje=es");
            }
        }
    }
