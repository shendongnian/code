		private Task<List<TAxEntity>> Deserialize(XmlReader reader)
		{
			var entities = reader.DeserializeSequence<TAxEntity>(EntityElementName, "" /* Pass the correct namespace here */).ToList();
			
			return Task.FromResult(entities);
		}		
		
