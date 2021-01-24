		public IEnumerable<T> ProccessCSV<T>(StreamReader document, char divider) 
			where T : class, new()
		{
			string currentLine = reader.ReadLine();
			string[] usedHeaders = currentLine.Split(divider);
			while ((currentLine = reader.ReadLine()) != null)
			{
				var fields = currentLine.Split(divider);
				var result = new T();
				for (var i = 0; i < usedHeaders.Length; i++)
					{
						var value = fields[i];
						var propInfo = typeof(T).GetProperties()[i];
						result.GetType()
								.GetProperty(propInfo.Name)
								.SetValue(result, value);
					}
				yield return result;
			}
		}
