    if (dbCon.IsConnect()){
                MySqlCommand idCmd = new MySqlCommand("Select * from " + da.DataGridView1.Text, dbCon.Connection);
                using (MySqlDataReader reader = idCmd.ExecuteReader()){
                  //  List<string> stringArray = new List<string>(); // you could use this string array to compare them, if you like this approach more.
                    while (reader.Read()){
                        var checkStatus= reader["Status"].ToString();
                        Console.WriteLine("Status: " + checkStatus.Split(' ').Count()); //checks how many items you've got.
                        foreach (var item in checkStatus.Split(' ').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray()){
                            var item2 = 0.0; // your 0 or 1 for avaliable or unavaliable..
                            try{
                                item2 = double.Parse(item.ToString());
                                if(strcmp(item2,'0') == 1){ //assuming you only have 0's and 1's.
                                  item2 = "unavaliable";
                                }else{
                                  item2 = "avaliable";
                                }
                            }
                            catch (Exception){
                                //do what you want
                            }
                            Console.WriteLine("item: " + item2);
                        }
                    }
                    dbCon.Close();
                }
            }
            return //what you want;
    }
