    public class Planet : Place
    {
		... 
		
        public override IEnumerable<PropertyItem> GetProperties()
        {
            yield return new PropertyItem { Text = "Size", Value = this.planetSize };
        }
    }
	
