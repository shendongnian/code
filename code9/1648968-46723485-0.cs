    <ContentControl.ContentTemplateSelector>
        <local:DocumentTemplateSelector FirstTemplate="{StaticResource  Pdf}" SecondTemplate="{StaticResource Image}"/>
    </ContentControl.ContentTemplateSelector>
    public class DocumentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstTemplate { get; set; }
        public DataTemplate SecondTemplate { get; set; }   
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        { 
            return FirstTemplate; 
        }
    }
