        public interface IModelMetadataFilter
        {
            void TransformMetadata(ModelMetadata metadata,
                 IEnumerable<Attribute> attributes);
        }
    public class MultilineTextByNameConvention : IModelMetadataFilter
        {
            public void TransformMetadata(ModelMetadata metadata, IEnumerable<Attribute> attributes)
            {
                if ( !string.IsNullOrEmpty(metadata.PropertyName) &&
                    string.IsNullOrEmpty(metadata.DataTypeName) )
                {
                    if ( metadata.PropertyName.ToLower().Contains("notes")
                        || metadata.PropertyName.ToLower().Contains("description")
                        || metadata.PropertyName.ToLower().Contains("comment")
                        )
                    {
                        metadata.DataTypeName = DataType.MultilineText.ToString();
                    }
                }
            }
        }
