    class MyClass {
       public virtual void MethodOne(IMyWayOfContextFactory contextFactory)) {
          using(var context = contextFactory.Create()){
              //play with context
          }
       }
       public virtual void MethodTwo(IMyWayOfContextFactory contextFactory) {
          using(var context = contextFactory.Create()){
              //play with context
          }
       }
    }
    public ContextFactory : IMyWayOfContextFactory {
         IMyWayOfContext Create(){
            return new MyWayOfContext();
         }
    }
