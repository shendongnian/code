        var roots = unsortedRows.Where(row => row.ParentId.HasValue == false).
            OrderBy(root => root.MenuName).ToList();
            
        foreach (csvRow root in roots)
        {
            root.addChildrenFrom(unsortedRows);
        }
            
        foreach (csvRow root in roots)
        {
            foreach (string FamilyMember in root.FamilyTree)
            {
                Console.WriteLine(FamilyMember);
            }
        }
        Console.Read();
    }
