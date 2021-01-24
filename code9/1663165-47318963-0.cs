    public interface IConsumable 
    {
        void Consume();
    }
    
    public abstract class AbstractConsumable : IConsumable
    {
        private bool _consumed = false;
    
    	public abstract void ConsumeEffects();
    	
        public void Consume()
        {
    		this.ConsumeEffects();
            _consumed = true;
        }
    }
    
    public class HealthyConsumable: AbstractConsumable
    {
        public override void ConsumeEffects()
        {
            // Do something healthy and ...
            // Consume will get called in the base
        }
    }
    
    public class PoisonousConsumable: AbstractConsumable
    {
        public override void ConsumeEffects()
        {
            // Do something poisonous and ...
            // Consume will get called in the base
        }
    }
