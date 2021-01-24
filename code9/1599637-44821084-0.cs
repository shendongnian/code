    public static void createHTML(DataTable table)
    {
        string templatePath = @"C:\Path\To\index.liquid";
        var template = Template.Parse(templatePath);
    
        using (StreamWrite file = new StreamWriter(@"C:\Some\Path\test.html"))
        {
            file.write(template.Render(Hash.FromAnonymousObject(new
            {
                table = DataMapper.createTable(table).toString()
            })));
        }
    }
