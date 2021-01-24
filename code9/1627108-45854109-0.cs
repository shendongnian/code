    public abstract class CGeometryCalibration2D<T> : CGeometryCalibration<T>
    {
      ctor()
      public override void Clear ()
      public bool Add (double i_dPosition, CGeometryCalibration1D<T> i_oGeoCalib1D)
      public bool Remove (double i_dPosition)
      public override void CopyTo (ref CGeometryCalibration<T> io_oGeoCalib)
      public override T Interpolate (CLocation i_locPosition, bool i_bExtrapolate = false)
      public T Interpolate (double i_dPosition, double i_dPositionGC1D, bool i_bExtrapolate = false)
      public override CResulT Load (CXmlDocReader i_xmldocreader)
      public override CResulT Save (CXmlDocWriter i_xmldocwriter)
    }
    public class CGeometryCalibration2D_Double : CGeometryCalibration2D<double>
    {
      ctor()
    }
    public class CGeometryCalibration2D_CLocation : CGeometryCalibration2D<CLocation>
    {
      ctor()
      public double InterpolateReverse (CLocation i_locValue, out CLocation o_ValueInterpolated, bool i_bExtrapolate = false)
    }
