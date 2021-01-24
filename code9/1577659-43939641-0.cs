    [HttpPost]
    [Authorize]
    [ActionName("EditModule")]
    public void EditModule(Modules module)
    {
        if (Dal.GetModule(module.PK_Code_Module) != null)
        {
            Dal.UpdateModule(int.Parse(module.PK_Code_Module), module.Libelle_Module, module.Capacite_Max_Module);
        }
        String URL = HttpContext.Request.Url.AbsoluteUri;
        string[] lines = Regex.Split(URL, "/");
        if (lines[lines.Length - 1] == "Parametres")
        {
            Response.Redirect("Parametres");
        }
        else
        {
            Response.Redirect("Index");
        }
    }
