	public class ExperimentViewModel
    {
        public int Id { get; set; }
		
        [DataType(DataType.Upload)]
        public IEnumerable<HttpPostedFileBase> FileUpload { get; set; }
		
		//other properties
    }
