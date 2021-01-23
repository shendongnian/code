            foreach(JObject item in array)
            {
				foreach(var prop in item.Children<JProperty>())
				{
					Console.WriteLine(prop.Name + ": " + prop.Value);
				}
                //Console.WriteLine(item.Children<JProperty>().FirstOrDefault().Name + ": " + item.Children<JProperty>().FirstOrDefault().Value);
 
            }
