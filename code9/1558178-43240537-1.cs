    public void Popular(IEnumerable<Computadora> computadoras)
    {
      var data = (from c in computadoras 
                    select new {
                              CodigoInterno = c.CodigoInterno,
                              Departamento = c.Departamento.Name, // If the department entity has a name property.
                             // assign the properties to be shown in grid like this
                              }).ToList();
        var bs = new BindingSource() {DataSource = data};
        dgvDatos.DataSource = bs;
    }
