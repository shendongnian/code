    public void PartOne() {
	while (rCatReader.Read())
                {
                    int rCatId = rCatReader.GetInt32(rCatIdOrdinal);
                    string rCatName = rCatReader.GetString(rCatNameOrdinal);
                    string rCatAbbre = rCatReader.GetString(rCatAbbreOrdinal);
                    int rCatParentId = rCatReader.GetInt32(rCatParentIdOrdinal);
			string data = rCatId + "," + rCatName+ "," + rCatAbbre+ "," + rCatParentId;
                   PartTwo(data);
                    }
    }
    public void PartTwo(string data) {
     	while (tCatReader.Read())
                        {
    			string source = data;
    			string[] stringSeparators = new string[] {","};
          			string[] result;
    			result = source.Split(stringSeparators, 
                                StringSplitOptions.RemoveEmptyEntries);
                        string TopCatParent = "";
                        int tCatParentId = 0;
                        int tCatId = tCatReader.GetInt32(tCatIdOrdinal);
                        string tCatName = tCatReader.GetString(tCatNameOrdinal);
                        string tCatAbbre = rCatReader.GetString(tCatAbbreOrdinal);
                        if (tCatReader.IsDBNull(tCatParentIdOrdinal) ==false)
                        {
                            tCatParentId = tCatReader.GetInt32(tCatParentIdOrdinal);
                        }                         
                        if (tCatParentId > 0)
                        {
                            SqlCommand cmdGetParentTopCategories = new SqlCommand("select TCatName from TopCategories where Id='" + tCatParentId + "'", con);
                            TopCatParent = cmdGetParentTopCategories.ExecuteScalar().ToString() + " -- ";
                        }
                        if (tCatId == rCatParentId)
                        {
                            cbBoxProductCategory.Items.Add(TopCatParent + tCatName + " -- " + rCatName);
                            cbBoxProductCategory.ValueMember = rCatId.ToString();
                        }
                }
