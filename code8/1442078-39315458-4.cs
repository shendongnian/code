        string[] Columns = new string[] { "Company", "Contact", "Country" };
        TableColumn FirstColumn = new TableColumn(new string[] { "Alfreds Futterkiste", "Maria Anders", "Germany" });
        TableColumn[] TableColumns = new TableColumn[] { FirstColumn };
        HTMLTable Table = new HTMLTable(Columns, TableColumns);      
        string HTMLString = HTMLTableGenerator.GenerateHTMLTable(Table);
        File.WriteAllText(@"C:\file.html", HTMLString);
