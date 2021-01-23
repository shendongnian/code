        public interface IVictim
        {
    	    string SharedProp { get; set; }
        }
    
    	public class TroopVictim : IVictim
    	{
    		public string SharedProp { get; set; }
    
    		public string TroopProperty { get; set; }
    	}
    
    	public class PopVictim : IVictim
    	{
    		public string SharedProp { get; set; }
    
    		public string PopProperty { get; set; }
    	}
    
    	public class MyGenericVictim
    	{
    		//Optional Property
    		public bool? IsTroopVictim
    		{
    			get
    			{
    				if (Victim == null) return null;
    				return Victim.GetType() == typeof(TroopVictim);
    			}
    		}
    
    		public IVictim Victim { get; set; }
    	}
    
    
    	public class UseMyOfVictim
    	{
    		public void Bar()
    		{
    			Foo(new MyGenericVictim
    			{
    				Victim = new TroopVictim(),
    			});
    		}
    
    		public void Foo(MyGenericVictim myvic)
    		{
    			//Function doesnt know TroopVic or PopVic
    
    			TroopVictim resolvedTroopVic;
    			PopVictim resolvedPopVictim;
    
    			if (myvic.Victim.GetType() == typeof(TroopVictim))
    			{
    				resolvedTroopVic = (TroopVictim) myvic.Victim;
    			}
    			else if (myvic.Victim.GetType() == typeof(PopVictim))
    			{
    				resolvedPopVictim = (PopVictim) myvic.Victim;
    			}
    
    			string success = resolvedPopVictim.PopProperty;
    			success = resolvedTroopVic.TroopProperty;
    		}
    	}
