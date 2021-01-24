    public class CustomContentTemplateSelector:DataTemplateSelector
    {
        public DataTemplate FirstDataTemplate {get; set;}
        public DataTemplate SecondDataTemplate {get; set;}
    
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container){
        // here you should impelement logic for choose data template 
        // if (condition) 
        //      return FirstDataTemplate
        // else
        //      return SecondDataTemplate
    }
    }
