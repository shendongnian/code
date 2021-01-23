    public string NomUtilisateur
    {
        get
        {
            return Request.Form["txtNomUtilisateur"];
        }
        set
        {
            txtNomUtilisateur.Text = value;
        }
    }
