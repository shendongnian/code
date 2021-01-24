    public class Journal
    {
    	private static Dictionary<Type, Func<JournalEntry>> _newFuncs = new Dictionary<System.Type, System.Func<UserQuery.Journal.JournalEntry>>();
    
    	public JournalEntry<T> NewJournalEntry<T>()
    	{
    		var newFunc = _newFuncs[typeof(T)];
    		return (JournalEntry<T>)newFunc();
    	}
    
    	public Journal() { }
    
    	public class JournalEntry { }
    
    	public class JournalEntry<T> : JournalEntry
    	{
    		static JournalEntry()
    		{
    			_newFuncs.Add(typeof(T), () => new JournalEntry<T>());
    		}
    
    		private JournalEntry()
    		{
    
    		}
    	}
    }
