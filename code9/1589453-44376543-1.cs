                foreach(DataRelation relation in dataSet.Tables["Artist"].ChildRelations) 
                {
                       foreach(DataRow row in  relation.ChildTable.AsEnumerable())
                       {
                           Console.WriteLine(string.Join(",", row.ItemArray.Select(x => x.ToString())));
                       }
                       DataTable dt2 = relation.ChildTable.AsEnumerable().CopyToDataTable();
                }
