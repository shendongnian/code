	public class Movie {
	  // existing properties
	  
	  
	  // this should not be mapped back to the EF store
	  public int NumberOfNullPropValues => typeof(Movie).GetProperties().Count(x => x.GetValue(this, null) == null);
	}
