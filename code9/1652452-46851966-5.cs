    public SortableBindingList<Candidate> RetrieveManyWithPicture(Candidate entity)
    {
    	var command = new SqlCommand { CommandText = "RetrievePictureCandidates", CommandType = CommandType.StoredProcedure };
    
    	command.Parameters.AddWithValue("@CandidateId", entity.CandidateId).Direction = ParameterDirection.Input;
    	
    
    	DataTable dt = SqlHelper.GetData(command); //this is where I retrieve the row from db, you have your own code for retrieving, so make sure it works.
    
    	var items = new SortableBindingList<Candidate>();
    
    	if (dt.Rows.Count <= 0) return items;
    	foreach (DataRow row in dt.Rows)
    	{
    		Candidate item = new Candidate();
    
    		item.CandidateId = row["CandidateId"].GetInt();
    		item.LastName = row["LastName"].GetString();
    		item.FirstName = row["FirstName"].GetString();
    
    		item.PictureId = row["PictureId"].GetInt();
    		item.PhotoType = PictureHelper.GetImage(row["Photo"]); //in my db, this is varbinary. in c#, this is byte[]
    
    		items.Add(item);
    
    	}
    
    	return items;
    }
