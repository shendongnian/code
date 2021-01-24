	var root = new MyObject() 
	{
		Name = "flare",
		Children = new List<MyObject>() 
		{
			new MyObject()
			{
				Name = "analytics",
				Children = new List<MyObject>() 
				{
					new MyObject()
					{
						Name = "cluster",
						Children = new List<MyObject>() 
						{
							new MyObject() { Name = "AgglomerativeCluster", Size = 3938 }
						}
					}
				}
			}
		}
	};
