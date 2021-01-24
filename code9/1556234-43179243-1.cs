    public abstract class CarVisitor 
    {
         public virtual Engine VisitEngine(Engine engine) 
         {
         }
    
         public virtual DieselEngine VisitDieselEngine(DieselEngine engine)
         {
         }
    }
    
    public sealed class MyCarVisitor : CarVisitor
    {
         public override DieselEngine VisitDieselEngine(DieselEngine engine)
         {
              VisitEngine(engine);
    
              return engine;
         }
    }
