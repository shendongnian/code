      public class DynamicDataTemplateSelector : DataTemplateSelector
            {
                public DataTemplate TextBoxTemplate{get;set;}
                public DataTemplate BooleanTemplate{get;set;}
        
                public DataTemplate NumericTemplate { get; set; }
                public DataTemplate ColorTemplate { get; set; }
                public override DataTemplate SelectTemplate(object item, DependencyObject container)
                {
                    DataTemplate dataTemplate = TextBoxTemplate;
                      if(item!=null)
                      {                  
                          Type dataTypeOfValue = item.GetType();
                          
                            if(dataTypeOfValue==typeof(int))
                           {
                               dataTemplate = NumericTemplate;
                           }
                           else if(dataTypeOfValue==typeof(Color))
        	               {
                               dataTemplate = ColorTemplate;
        	               }
        
                           else if (dataTypeOfValue == typeof(Boolean) || dataTypeOfValue == typeof(bool))
                            {
                                dataTemplate = BooleanTemplate;
                            }
        
                      }
                     return dataTemplate;
                }
  
