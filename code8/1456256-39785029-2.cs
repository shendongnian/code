	public bool InsertQualifications(List<Qualification> quali,int newid) //Getting the List values
	{ 
		foreach (Qualification q in quali) // This is where the issues comes only one set of object is passed to the database
		{ 
			try
			{
				var status = db.AddQualiDetails("Insert_QualiDetails", q.Description, q.University, q.Date_of_award, q.Qauli_id, q.Quali_type, newid, q.Duration);
				return true; <<<<<-------
			}
			catch (Exception)
			{
				return false;
			}
		}
		return true;
	}
