    using Dapper;
    ...
    IDictionary<string, decimal> products; 
    using(var connection = new SqlConnection(GetConnectionString()))
    {
        connection.Open();
        products = connection.Query("SELECT name, price FROM products;")
            .ToDictionary(
                row => (string)row.Name,
                row => (decimal)row.Price);
    }
