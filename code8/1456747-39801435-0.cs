    [ChildActionOnly]        
    public PartialViewResult ListaTipoDeUsuarios()
    {
      string dtTipoUser = client.GetTiposUsuario("{}");
      DataTable dt = (DataTable)JsonConvert.DeserializeObject(dtTipoUser, typeof(DataTable));
      List<SelectListItem> listaTiposUsuarios = new List<SelectListItem>();
      foreach (DataRow row in dt.Rows)
      {
        TipoUsuarioBO tipoUsuario = new TipoUsuarioBO();
        tipoUsuario = TiposUsuarioBR.MapeoTipoUsuario(row, tipoUsuario);
        listaTiposUsuarios.Add(new SelectListItem()
          {
            Text = tipoUsuario.Id+"-"+tipoUsuario.Descripcion,
            Value = tipoUsuario.Id.ToString(),
            Selected = true //if you want this item selected otherwise false
          });
      }      
      return PartialView(listaTiposUsuarios);
    }
