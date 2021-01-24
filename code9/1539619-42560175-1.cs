    public class ControllerImplA : IController
    {
        public void doSomething(IEntity entity)
        {
            this.doSomething((EntityImplA) entity);
        }
        public void doSomething(EntityImplA entity)
        {
            ...
        }
    }
