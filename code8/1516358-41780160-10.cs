		public interface ICritical
		{
			// Required to do any real job
			IntPtr CriticalHandle { get; }
		}
		public class Base
		{
			public Base(ICritical critical) 
            { 
                 if (!(critical is MyOnlyTrueImplementation)) 
                     throw ...  
            }
		}
		public class Derived : Base
		{
            // They can't have a constructor without ICritical and you can check that you are getting you own ICritical implementation.
			public Derived(ICritical critical) : base(critical) 
            {        }
		}
		
