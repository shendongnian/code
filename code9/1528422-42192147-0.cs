    using System;
    namespace Accord.Math.Random
    {
    	public interface IRandomNumberGenerator<T>
    	{
    		T[] Generate(int samples);
    		T[] Generate(int samples, T[] result);
    		T Generate();
    	}
    }
