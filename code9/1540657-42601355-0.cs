    using System;
    #region USING_FLOAT
    #if USE_FLOAT
    using mFloatType = System.Single;
    using mComplexType = CenterSpace.NMath.Core.FloatComplex;
    using mComplexVector = CenterSpace.NMath.Core.FloatComplexVector;
    using mComplexMatrix = CenterSpace.NMath.Core.FloatComplexMatrix;
    using mHermitianMatrix = CenterSpace.NMath.Matrix.FloatHermitianMatrix;
    #else
    using mFloatType = System.Double;
    using mComplexType = CenterSpace.NMath.Core.DoubleComplex;
    using mComplexVector = CenterSpace.NMath.Core.DoubleComplexVector;
    using mComplexMatrix = CenterSpace.NMath.Core.DoubleComplexMatrix;
    using mHermitianMatrix = CenterSpace.NMath.Matrix.DoubleHermitianMatrix;
    #endif
    #endregion
    
    namespace TypeFactory
    {
    	public static class CenterLineFactory
    	{
           public static mFloatType Double { get { return new mFloatType(); } }
           public static mComplexType ComplexType { get { return new  mComplexType(); } }
           ~~~ etc ~~~
    	}
    }
