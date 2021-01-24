    public class ControllerImplA : IController<EntityImplA>
    {
        public void doSomething(EntityImplA entity)
        {
            EntityImplA entityForA = entity;
            ...
        }
}
