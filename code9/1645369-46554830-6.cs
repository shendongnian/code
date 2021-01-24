		static public HexString operator ^(HexString LHS, HexString RHS)
		{
			var left = LHS._data;
			var right = RHS._data;
			if (left.Length != right.Length) throw new InvalidOperationException("Hex strings must be the same length to be XOR'd.");
			var result = new byte[left.Length];
			for (int i = left.GetLowerBound(0); i<= left.GetUpperBound(0); i++)
			{
				result[i] = (byte)(left[i] ^ right[i]);
			}
			return new HexString(result);
		} 
