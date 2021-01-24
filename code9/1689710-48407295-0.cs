    public override void up(){             
         Create.Column("Name").OnTable("Table2");
         Execute.Sql("UPDATE table2 Inner join table1 on table2.Id = table1.Id set table2.Name = table1.Name");
         Delete.Column("Name").FromTable("Table1");
    }
