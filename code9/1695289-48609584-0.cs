    public List<SelectListItem> GetMedidas()
    {
        return db.MuebleVanitorios
                        .Select(m => new SelectListItem { 
                             Text=m.Largo + "X" + m.Ancho + "X" + m.Alto, 
                             Value=m.v_Nombre})
                        .ToList();
    }
