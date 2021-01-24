    		public IEnumerable<Logs> GetLogsByName(string lookupname)
		{
			List<Logs> mylist = Logs.ToList<Logs>();
			return  mylist.Where(p => p.LoggerName.Contains(lookupname)).ToList();
			
		}
