    protected void btnConnexion_Click(object sender, EventArgs e)
    {
    	Session["NomUtilisateur"] = txtNomUtilisateur.Text;
    	Session["MotDePasse"] = FormsAuthentication.HashPasswordForStoringInConfigFile(txtMotDePasse.Text, "MD5");
    
    	if (Authentifier(txtNomUtilisateur.Text, txtMotDePasse.Text))
    	{
    		FormsAuthentication.RedirectFromLoginPage(txtNomUtilisateur.Text, false);
    	}
    	else
    	{
    		ErreurConnexion.Visible = true;
    		lblErreurConnexion.ForeColor = System.Drawing.Color.Red;
    		lblErreurConnexion.Text = "Erreur d'authentification : Le nom d'utilisateur ou le mot de passe est incorrect.";
    	}
    }
