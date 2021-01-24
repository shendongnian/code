    public class CGeometryCalibration2D<T> where T: struct
    {
    	public double InterpolateReverse<V>(V i_Value) where V: struct, ICLocation
    	{
    		return default(double);
    	}
    }
    
    public interface ICLocation { }
    
    public struct CLocation : ICLocation { }
