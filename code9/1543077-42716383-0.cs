    			_groups = new DataSet();
    			_groups.Tables.Add(new DataTable("users"));
    			_groups.Tables.Add(new DataTable("groups"));    
    
                    _groups.Tables[0].Columns.Add("id_user", typeof(int));
        			_groups.Tables[0].Columns.Add("user_name");
        			_groups.Tables[0].Columns.Add("id_group", typeof(int));
        			_groups.Tables[1].Columns.Add("id_group", typeof(int));
        			_groups.Tables[1].Columns.Add("group_name");
        			_groups.Tables[0].Rows.Add(1, "Nom1", 1);
        			_groups.Tables[0].Rows.Add(2, "Nom2", 2);
        			_groups.Tables[0].Rows.Add(3, "Nom3", null);
        			_groups.Tables[1].Rows.Add(1, "Group1");
        			_groups.Tables[1].Rows.Add(2, "Group2");
        			Console.WriteLine(_groups.GetXml());
        
        			var result = _groups.Tables[0].AsEnumerable()
                        .Where(user => user.Field<int>("id_user") == 1)
        				.Join(_groups.Tables[1].AsEnumerable(), user => user.Field<int?>("id_group"), group => group.Field<int>("id_group"), (user, group) => new { id_user = user.Field<int>("id_user"), group_name = group.Field<string>("group_name") }).First();
        
        			Console.WriteLine(result.group_name);
        
        			var result2 = _groups.Tables[0].AsEnumerable()
                        .Where(user => user.Field<int>("id_user") == 3)
        				.Join(_groups.Tables[1].AsEnumerable(), user => user.Field<int?>("id_group"), group => group.Field<int>("id_group"), (user, group) => new { id_user = user.Field<int>("id_user"), group_name = group.Field<string>("group_name") }).FirstOrDefault();
        
        			Console.WriteLine(result2 != null? result2.group_name:null);
        
        			Console.ReadLine();
 
