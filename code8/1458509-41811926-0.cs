    public static DbSet<T> AsDbSet<T>(this List<T> sourceList, Func<T, object> primaryKey = null) where T : class
    {
    	//all your other stuff still goes here
    	
    	if (primaryKey != null)
        {
            mockSet.Setup(set => set.Find(It.IsAny<object[]>())).Returns((object[] input) => sourceList.SingleOrDefault(x => (Guid)primaryKey(x) == (Guid)input.First()));
        }
        ...
    }
