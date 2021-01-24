    try
    {
        _unitOfWork.Repository<Product>().InsertEntity(product);
         await _unitOfWork.SaveChangesAsync();//This throws exception due the model validation failure
    }
    catch (Exception exception)
    {
        ExceptionModel exceptionModel = new ExceptionModel();
        string connectionString = _configuration.GetConnectionString("MyConnection");
        var options = new DbContextOptionsBuilder<MyDbContext>()
                    .UseSqlServer(new SqlConnection(connectionString))
                    .Options;
        using (var dbContext = new MyDbContext(options))
        {
             using (var transaction = dbContext.Database.BeginTransaction())
             {
                 try
                 {
                       dbContext.Exceptions.Add(exceptionModel);
                       await dbContext.SaveChangesAsync();
                       transaction.Commit();
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e);
                     throw;
                 }
             }
         }
    }
