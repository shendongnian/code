    public abstract class TemplateEnforcer
    {
        private void TheSame()
        {
            Console.WriteLine("Everyone calls me;");
        }
        sealed public void TemplateMethod()
        {
            this.TheSame();
            this.NeedsImplementation();
        }
        protected abstract void NeedsImplementation();
    }
    public class TemplateImplementer : TemplateEnforcer
    {
        protected override void NeedsImplementation()
        {
            Console.WriteLine("Implemented in TemplateImplementer");
        }
    }
