       public class User
        {
            public string list_studid { get; set; }
            public string list_studfname { get; set; }
            public string list_studmname { get; set; }
            public string list_studlname { get; set; }
            
        }
       public void cmdSearch_Click(object sender, RoutedEventArgs e)
       {
            NpgsqlConnection iConnect = new NpgsqlConnection
                                            ("Server = " + myModule.Server + ";
                                              Port = " + myModule.Port + ";
                                              User ID = " + myModule.UserID + ";
                                              Password = " + myModule.Password + ";
                                              Database = " + myModule.Database);
            iConnect.Open();
            NpgsqlCommand iQuery = new NpgsqlCommand("Select * from tblstudents_secure", iConnect);
            iQuery.Connection = iConnect;
            NpgsqlDataAdapter iAdapter = new NpgsqlDataAdapter(iQuery);
            DataSet iDataSet = new DataSet();
            iAdapter.Fill(iDataSet, "LIST");
            
            int lstCount = iDataSet.Tables["LIST"].Rows.Count;//lstCount holds the total count of the list from database
            int i = 0;//used as counter
            List<User> items = new List<User>();
            while (lstCount > i)
            {
                items.Add(new User()
                {
                    list_studid = iDataSet.Tables["LIST"].Rows[i]["stud_id"].ToString(),
                    list_studfname = iDataSet.Tables["LIST"].Rows[i]["stud_fname"].ToString(),
                    list_studmname = iDataSet.Tables["LIST"].Rows[i]["stud_mname"].ToString(),
                    list_studlname = iDataSet.Tables["LIST"].Rows[i]["stud_lname"].ToString()
                });
                lvDataBinding.ItemsSource = items;//lvDataBinding is the name of my ListView
                i++;
            }
       }
