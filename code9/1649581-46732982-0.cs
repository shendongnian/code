    public void ReadFile()
    {
        string folderPath = @"C:\Users\patri\source\repos\DietMate\";
        string fileName = "ProductsDatabase.txt";
        string fullPath = Path.Combine(folderPath, fileName);
        //insert code to check whether file exists.
        // use Exists()    
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            File.Create(fullPath);
        }
        //if yes, follow with code below
        //insert code for reading from file
        using (StreamReader ProductsDatabaseRead = new StreamReader(fullPath))
        {
            ProductTest.Text = ProductsDatabaseRead.ReadLine();
        }
    }
