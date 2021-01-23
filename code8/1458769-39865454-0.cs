    using System.Data.Entity;
    
    public static IEnumerable<Categoria> GetCategories()
    {
        using (var db = new PresupuestoContext())
        {
            var query = (from b in db.Categorias
                        orderby b.Nombre
                        select b)
                        .Include(p => p.SubCategorias)
                        .ToList();
    
            return query;
        }
    } 
