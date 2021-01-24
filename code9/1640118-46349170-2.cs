        private void cargaComboLenguajes()
        {
            if (Session["cmbIdioma"].ToString() != "")
            {
                cmbIdioma.SelectedValue = Session["cmbIdioma"].ToString();
            }
            else
            {
                cmbIdioma.SelectedValue = "en-us";
                Session["cmbIdioma"] = "en-us";
            }
        }
        protected void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = cmbIdioma.SelectedValue;
            if (!string.IsNullOrEmpty(language))
            {
                Session["cmbIdioma"] = cmbIdioma.SelectedValue.ToString();
                Response.Redirect("Default.aspx?lenguaje=" + Session["cmbIdioma"].ToString());
            }
        }
