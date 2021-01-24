    public class Extension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IPublicInterface, InternalClassImpl>();
        }
    }
    public interface IPublicInterface
    {
    }
    internal class InternalClassImpl : IPublicInterface
    {
        public InternalClassImpl()
        {
        }
    }
