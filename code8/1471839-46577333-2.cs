    public class IndexViewModel : ViewModelBase
    {
        public string ViewOnlyProperty { get; set; }
        public string ExposedDataModelProperty { get; set; }
        public IndexViewModel(IndexDataModel model) : base(model)
        {
            ExposedDataModelProperty = model?.Property;
            ViewOnlyProperty = ExposedDataModelProperty + " for a View";
        }
        public IndexViewModel(ObjectResult apiResult) : this(apiResult.Value as IndexDataModel) { }
    }
    public class ViewModelBase
    {
        protected ApiModelBase _model;
        public ViewModelBase(ApiModelBase model)
        {
            _model = model;
        }
    }
    public class ApiModelBase { }
    public class IndexDataModel : ApiModelBase
    {
        public string Property { get; internal set; }
    }
