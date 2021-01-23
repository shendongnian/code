    public interface IAction<TAppliesTo> where TAppliesTo : IActor
    {
        void Perform(TAppliesTo appliesTo);
    }
    public class UniversalAction : IAction<IActor>
    {
       public void Perform (IActor anyone) {}
    }
  
    public class HealthPotion : IAction<IHealthUser>
    {
       public void Perform (IHealthUser healthUserOnly){}
    }
