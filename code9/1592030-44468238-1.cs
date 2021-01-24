    public class BaseClass
    {
        public virtual void ClassName()
        {
            // How can I get the name of the base class "BaseClass" here, without having to hardcode "BaseClass"?
            Console.WriteLine(nameof(BaseClass)); 
        }
    }
    
    public class SubClass: BaseClass
    {
        public override void ClassName()
        {
            base.ClassName();
            Console.WriteLine(nameof(SubClass));
        }
    }
