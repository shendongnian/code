    public interface IAutoStart()
    {
        void Start();
    }
    public class SomeClassThatStarts : IAutoStart
    {
        public void Start()
        {
            Console.Log("Starting!");
        }
    }
    public class AutoStartModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            foreach(var starter in Kernel.GetAll<IAutoStart>())
            {
                starter.Start();
            }
        }
    }
