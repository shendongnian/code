    /// <summary>
    /// Calculates the modulus of the power of a mutiple. 
    /// </summary>
    /// <param name="modularBase">Modulus base.</param>
    /// <param name="value">Value to be powered</param>
    /// <param name="pow">Number of powers</param>
    /// <returns></returns>
    static long GetModularOfPOW(int modularBase, int value, uint pow)
    {
    	return GetModularOf(modularBase, (pow > uint.MinValue) ? Enumerable.Repeat(value, (int)pow).ToArray() : new int[] { value });
    }
    
    /// <summary>
    /// Calculates the modulus of the multiples. 
    /// </summary>
    /// <param name="modularBase">The modulus base.</param>
    /// <param name="multiples">The multiples of the number.</param>
    /// <returns>modulus</returns>
    static long GetModularOf(int modularBase, params int[] multiples)
    {
    	/**
    	* 1. create a stack from the array of numbers.
    	* 2. take the 1st and 2nd number from the stack and mutiply their modulus
    	* 3. push the modulus of the result into the stack.
    	* 4. Repeat 2 -> 3 until the stack has only 1 number remaining.
    	* 5. Return the modulus of the last remaing number.
    	*
    	* NOTE: we are converting the numbers to long before performing the arthmetic operations to bypass overflow exceptions.
    	*/
    	var result = new Stack(multiples);
    	while (result.Count > 1)
    	{
    		long temp = (Convert.ToInt64(result.Pop()) % Convert.ToInt64(modularBase)) * (Convert.ToInt64(result.Pop()) % Convert.ToInt64(modularBase));                
    		result.Push(temp % modularBase);
    	}
    
    	return Convert.ToInt64(result.Pop()) % Convert.ToInt64(modularBase);
    }
