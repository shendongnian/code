	// main model
    public class Model
    {
        public long Id { get; set; }
        public virtual ICollection<NameValuePair> NameValuePairs { get; set; }
        // other properties ...
    }
	
	// complex type
    public class NameValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }
        // other properties ...
    }
	
	// builder
	builder.EntitySet<Model>("Models");
	builder.EntitySet<NameValuePair>("NameValuePairs");
	
