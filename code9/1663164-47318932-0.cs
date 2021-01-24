    public interface IConsumable 
    {
        void Consume();
    }
    
    public abstract class AbstractConsumable : IConsumable
    {
        private bool _consumed = false;
    
        public void Consume()
        {
            _consumed = true;
            InternalConsumerBehaviour();
        }
        
        protected virtual void InternalConsumeBehaviour()
        {
             //default do nothing could potentially mark this method abstract rather than virtual its up to you
        }
    }
    
    public class HealthyConsumable: AbstractConsumable
    {
        protected override void InternalConsumeBehaviour()
        {
            // Do something healthy and ...
        }
    }
    
    public class PoisonousConsumable: AbstractConsumable
    {
        protected override void InternalConsumeBehaviour()
        {
            // Do something poisonous and ...
        }
    }
