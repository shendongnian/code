     public IHttpActionResult Get()
        {
            var maquinas = _cobraAppContext.Maquina
                .Include(m => m.IdMarcaMotorNavigation)
                .Include(m => m.IdModeloNavigation)
                .ToList();
            return Ok(maquinas);//Two or more object obtains :(
        }
