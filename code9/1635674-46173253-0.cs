    struct TableStructure
    {
        public int Id { get; set; }
        public string Column { get; set; }
    }
    
    var t1 = new List<TableStructure>() { new TableStructure { Id = 1, Column = "val1" }, new TableStructure { Id = 2, Column = "val2" } };
    var t2 = new List<TableStructure>() { new TableStructure { Id = 1, Column = "val3" }, new TableStructure { Id = 2, Column = "val4" } };
    var t3 = new List<TableStructure>() { new TableStructure { Id = 1, Column = "val5" }, new TableStructure { Id = 2, Column = "val6" } };
    
    var result = ((from row1 in t1 select new { row1.Id, row1.Column, SourceTable = "table1" })
            .Union(from row2 in t2 select new { row2.Id, row2.Column, SourceTable = "table2" })
            .Union(from row3 in t3 select new { row3.Id, row3.Column, SourceTable = "table3" }))
            .AsEnumerable().Select((row, index) => new { RowNum = index + 1, row.Id, row.Column, row.SourceTable });
    
    result.ToList().ForEach(row => Console.WriteLine($"{row.RowNum}, {row.Id}, {row.Column}, {row.SourceTable}"));
