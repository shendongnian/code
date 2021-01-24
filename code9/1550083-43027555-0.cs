    public class BasedOnWithContextExtension : MarkupExtension 
    {
        public BasedOnWIthContextExtension() 
        {
        }
        
        public DependencyObject Context {get; set;} 
        public Type TargetType {get; set;} 
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Context?.FindResource(this.TargetType) as Style;
        }
    }
