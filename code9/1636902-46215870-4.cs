	Graad _myGrade;
	
	public Graad GradeOfPerson
	{
		get { return _myGrade; }
		set
		{
			if (value = Graad.Steward || value = Graad.Purser)
			{
				throw new Exception("Not Allowed");
			}
			_myGrade = value; 
		}
	}
