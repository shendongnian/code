    // create your objects
    var matrix = // in my prod code I create in excess of 32,600+ matrix cells
    foreach (var cell in cellsToAdd)
    {
        matrix.Cells.Add(cell);
    }
    using (var context = new MyDbContext())
    {
        context.Matrices.Add (newMatrix);
    
        await context.SaveChangesAsync();
    }
