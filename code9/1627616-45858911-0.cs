        public interface IParentContainer
        {
        }
        
        public abstract class ParentContainer<T> : IParentContainer
        	where T: ParentFoo
        {
            //snip
        }
    
    And now you can have your list like this:
    
    	var containers = new List<IParentContainer>
    	{
    		new ChildContainer(),
    		new ChildContainer2()
    	};
