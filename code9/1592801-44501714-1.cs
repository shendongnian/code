    public ActionResult IndexContratos(int id)
    {
	     var anexos = db.Anexos
			.Include(a => a.Contrato)
			.Include(a => a.Pessoa)
			.Include(a => a.TipoDocumento)
			.Where(x => x.ContratoId == id);
		  AnexosContratoTemps(id);
		  return View("Grid", anexos.AsEnumerable());//Works !!
          //return View("Grid", anexos.ToList()); //Invalid column name...
	}
