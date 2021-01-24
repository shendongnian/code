    public static void CreateLingerieBrandsDatabase(string brand)
    {
        SqlConnection createBrandData = new SqlConnection(@"Data Source=Y560\SQLEXPRESS;Initial Catalog=LingerieItemsDB;Integrated Security=True");
        createBrandData.Open();
        if (!Regex.Match(brand, @"^(?:Glamory|Evgenia|Victoria)$", RegexOptions.IgnoreCase).Success)
            throw new ArgumentException("Invalid brand");
        SqlCommand cmdBrandData = new SqlCommand("CREATE TABLE lingerieItem" + brand + "(id int,type char(50),model char(50),price float,image1 char(255),image2 char(255),description text, [neck type], [color] char(50)); ", createBrandData);
        cmdBrandData.ExecuteNonQuery();
        createBrandData.Close();
    }
