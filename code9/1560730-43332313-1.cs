    public Task Index()
    { 
       var marca = _context.GetMarca();
       //map marca to MyModel here
       var model = new MyModel()
       {
          Iva = marca.Iva,
          Path = marca.Path
          // other properties
       }
       return Index(model);
    }
    public async Task<IActionResult> Create(MyModel model)
    {
         var entity = _context.GetEntityByID(model.Iva);
         entity.Path = model.Path
         //map other properties
         await _context.SaveChanges();
    }
