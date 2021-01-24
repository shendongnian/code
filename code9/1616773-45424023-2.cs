    var tiposcargas = _pService.Select(item => new VehiculoGetViewModel()
        {
            ID = item.ID,
            Nombre = item.Nombre,
            NombreEstatus = item.Estatus.Nombre,
            NombreContenedor = item.CatalogosRegistro.Nombre
        }).ToList();
