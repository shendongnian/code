    public class CustomRangeAttributeAdapter : RangeAttributeAdapter
        {
            public CustomRangeAttributeAdapter(ModelMetadata metadata,
                                              ControllerContext context,
                                              RangeAttribute attribute)
                   : base(metadata, context, attribute)
            {
                attribute.ErrorMessageResourceName = <Resource_Name_Here>;
                attribute.ErrorMessageResourceType = typeof(<Resource_File_Name>);
                metadata.DataTypeName = DataType.Currency.ToString();
            }
        } 
