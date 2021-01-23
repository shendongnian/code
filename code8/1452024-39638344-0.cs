    public class DataReload
    {
        public string email_address { get; set; }
        public string status { get; set; }
        private MergeFieldsReload _merge_fields = new  MergeFieldsReload();
    
        public MergeFieldsReload Merge_Fields
        {
           get { return _merge_fields ; }
           set { _merge_fields = value ;}
        }
    }
