    ctx.Items.Include(e => e.ItemNav1)
             .Include(e => e.ItemNav2)
             .Include(e => e.ItemNav3)
             .Include(e => e.ItemNav4)
             .Include(e => e.ItemNav5)
             .Include(e => e.ItemNav6)
             .Where(<filter criteria>)
             .ToList();
