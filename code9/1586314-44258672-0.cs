    using System;
					
    public class Program
    {
	    internal interface IMasterService<in T> {
            void DoSomething(T table);
        }
        internal class BaseClass {}
        internal class DerivedClass : BaseClass {}
        internal class SpezializedService : IMasterService<BaseClass> {
		    public void DoSomething(BaseClass table) {}
	    }
	    public static void Main()
	    {
            // The compiler isn't happy about the other way around
        	IMasterService<DerivedClass> baseService = new SpezializedService();
	    }
    }
