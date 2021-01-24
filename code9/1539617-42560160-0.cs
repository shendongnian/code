    public interface IController {
        void DoSomething(IEntity thing);
    }
    
    public interface IEntity { ... }
    
    abstract class AbstractController<TEntity> : IController where TEntity : IEntity {
    	public void DoSomething(IEntity e) {
            // Forward the call to an abstract method with more specific type
    		DoSomethingImpl((TEntity)e);
    	}
        // Subclasses need to implement this method instead of the interface method:
    	protected abstract void DoSomethingImpl(TEntity e);
    }
