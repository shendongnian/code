    public class Set : Task
	{
	
		TaskLoggingHelper log;
		
		public Set() {
			log = new TaskLoggingHelper(this);
		}
		
		[Required]
		public ITaskItem[] Output { get; set; }
		public override bool Execute()
		{
			log.LogMessage("start set");
			foreach(var item in Output)
			{
				log.LogMessage(String.Format("Set sees key {0} with value {1}.",item.ItemSpec, item.GetMetadata("value")));
			}
            log.LogMessage("end set");
			return true;
		}
	}
	public class Get : Task
	{
	
        // notice this property no longer is called Output
        // as that gave me errors as the property is reserved		
		[Output]
		public ITaskItem[] Result { get; set; }
		public override bool Execute()
		{
            // convert a Dictionary or Hashset to an array of ITaskItems
            // by creating instances of the class KeyValue.
            // I use a simple list here, I leave it as an exercise to do the other colletions
			Result = new List<ITaskItem> { new KeyValue("bar", "bar-val"), new KeyValue("foo","foo val") }.ToArray();
			return true;
		}
	}
