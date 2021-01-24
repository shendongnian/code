	class C 
    {
		public static void M<T>(T t) where T : DataObject, IWriteData 
		{
			List<T> myList = new List<T>() { t };
            // With this restriction we can make both these conversions:
            IEnumerable<DataObject> iedo = myList; // Legal
            IEnumerable<IWriteData> iewd = myList; // Legal 
		}
	}
