    public class HugeInt
    {
    	// The array that contains all the digits of the number. To create a new number, you do not change this array but instead you create a new instance of HugeInt.
    	// The first digit is the least significant digit.
    	private readonly int[] digits; 
    
    	public HugeInt(string number)
    	{
    		// Trim off the leading zeros
    		number = number.TrimStart('0');
            if (number == "")
    	        number = "0";
    		
    		// Convert to digit array with the least significant digit first
    		digits = number.ToCharArray().Select(c => int.Parse(c.ToString())).Reverse().ToArray();
    	}
    
    	public HugeInt(IList<int> digits)
    	{
    		// Trim off the leading zeros
    		var d = digits.ToList();
    		while (d.Count > 1 && d.Last() == 0)
    			d.RemoveAt(d.Count - 1);
    		
    		// Convert to digit array with the least significant digit first
    		this.digits = d.ToArray();
    	}
    
    	public HugeInt Plus(HugeInt num)
    	{
    		// Add to positive integers by adding each digit together, starting with the least significant digit. 
    		var result = new List<int>();
    		int carry = 0;
    		for (var i = 0; i < this.digits.Length || i < num.digits.Length; i++)
    		{
    			var digit1 = i < this.digits.Length ? this.digits[i] : 0;
    			var digit2 = i < num.digits.Length ? num.digits[i] : 0;
    			var digitResult = digit1 + digit2 + carry;
    			carry = 0;
    			if (digitResult >= 10)
    			{
    				digitResult -= 10;
    				carry = 1;
    			}
    			result.Add(digitResult);
    		}
    		if (carry > 0)
    			result.Add(carry);
    
    		return new HugeInt(result);
    	}
    
    	public int CompareTo(HugeInt num)
    	{
    		// First compare by length of number
    		if (this.digits.Length > num.digits.Length)
    			return -1;
    		else if (this.digits.Length < num.digits.Length)
    			return 1;
    		else
    		{
    			// If lengths are equal, then compare each digit - starting with the most significant digit.
    			for (var i = this.digits.Length - 1; i >= 0; i--)
    			{
    				var cmp = this.digits[i].CompareTo(num.digits[i]);
    				if (cmp != 0)
    					return cmp;
    			}
    			return 0;
    		}
    	}
    
    	public override string ToString()
    	{
    		return String.Join("", digits.Reverse());
    	}
    }
