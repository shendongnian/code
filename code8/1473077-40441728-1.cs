    namespace CustomControls.Design
    {
        public class Metadata : IProvideAttributeTable
        {
            AttributeTable IProvideAttributeTable.AttributeTable
            {
                get
                {
                    AttributeTableBuilder builder = new AttributeTableBuilder();
                    Assembly assembly = Assembly.GetAssembly(typeof(CustomControls.CustomButton));
                    
                    foreach (Type objectType in assembly.GetTypes())
                    {
                        if (objectType.IsPublic && typeof(FrameworkElement).IsAssignableFrom(objectType))
                        {
                            builder.AddCustomAttributes(objectType,
                                ToolboxBrowsableAttribute.No);
                        }
                    }
                    
                    return builder.CreateTable();
                }
            }
        }
    }
