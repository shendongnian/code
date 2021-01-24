    List<object> myObjects = new List<object>();
			myObjects.Add(1);
			myObjects.Add("Ravi");
			myObjects.Add(new DateTime());
			for (var i = 0; i < myObjects.Count; i++)
			{
				var myObject = myObjects[i];
				if (myObject is int) // or can use if(myObject.GetType() == typeof(int))
				{
					
				}
				else if (myObject is string)
				{
				}
				else if (myObject is DateTime)
				{
				}
			}
