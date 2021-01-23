	class MatrixModel {
		public string ProfileId {get; set;}
		public string Caste {get; set;}
		public string Country {get; set;}
		public string City {get; set;}
		public string Occupation {get; set;}
		public string MotherTongue {get; set;}
	}
	
	public static void Main()
	{
		var db = new MatrixModel[]{
			new MatrixModel {
				ProfileId = "1",
				Caste = "Caste1",
				Country = "USA",
				City = "Miami",
				Occupation = "System administrator",
				MotherTongue = "English"
			},
			new MatrixModel {
				ProfileId = "2",
				Caste = "Caste1",
				Country = "India",
				City = "Mumbai",
				Occupation = "developer",
				MotherTongue = "English"
			},		
			new MatrixModel {
				ProfileId = "3",
				Caste = "Caste1",
				Country = "England",
				City = "London",
				Occupation = "developer",
				MotherTongue = "English"
			},				
		};
		string s = "Caste1, England";
		string[] words = s.Split(',');
		int count = words.Length;
		if (count <= 5)
		{
                    IEnumerable<MatrixModel> KeyWord = db;
                    foreach(var par in words) 
                    {
                        var parTrimmed = par.Trim();
                        KeyWord = KeyWord
                            .Where(x => x.Caste == parTrimmed
                                || x.Country == parTrimmed
                                || x.City == parTrimmed
                                || x.Occupation == parTrimmed 
                                || x.MotherTongue == parTrimmed);
                    }
                    var result = KeyWord.Select(x => new
                        {
                            ProfileID = x.ProfileId,
                        }).ToList();
                    
                    foreach(var item in result){
                        Console.WriteLine(item);
                    }
 	        }
	}
	
