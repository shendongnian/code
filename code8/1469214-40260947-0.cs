	/// <summary>
	/// Calculates a hash code based on multiple hash codes.
	/// </summary>
	public struct HashCode
	{
		private const int _seed = 5923;
		private const int _multiplier = 7481;
		/// <summary>
		/// Builds a new hash code.
		/// </summary>
		/// <returns>The built hash code.</returns>
		public static HashCode Build() => new HashCode(_seed);
		/// <summary>
		/// Constructor from a hash value.
		/// </summary>
		/// <param name="value">Hash value.</param>
		private HashCode(int value)
		{
			_value = value;
		}
		/// <summary>
		/// Builds a new hash code and initializes it from a hash code source.
		/// </summary>
		/// <param name="hashCodeSource">Item from which a hash code can be extracted (using GetHashCode).</param>
		public HashCode(object hashCodeSource)
		{
			int sourceHashCode = GetHashCode(hashCodeSource);
			_value = AddValue(_seed, sourceHashCode);
		}
		private readonly int _value;
		/// <summary>
		/// Returns the hash code for a given hash code source (0 if the source is null).
		/// </summary>
		/// <param name="hashCodeSource">Item from which a hash code can be extracted (using GetHashCode).</param>
		/// <returns>The hash code.</returns>
		private static int GetHashCode(object hashCodeSource) => (hashCodeSource != null) ? hashCodeSource.GetHashCode() : 0;
		/// <summary>
		/// Adds a new hash value to a hash code.
		/// </summary>
		/// <param name="currentValue">Current hash value.</param>
		/// <param name="valueToAdd">Value to add.</param>
		/// <returns>The new hash value.</returns>
		private static int AddValue(int currentValue, int valueToAdd)
		{
			unchecked
			{
				return (currentValue * _multiplier) + valueToAdd;
			}
		}
		/// <summary>
		/// Adds an object's hash code.
		/// </summary>
		/// <param name="hashCode">Hash code to which the object's hash code has to be added.</param>
		/// <param name="hashCodeSource">Item from which a hash code can be extracted (using GetHashCode).</param>
		/// <returns>The updated hash instance.</returns>
		public static HashCode operator +(HashCode hashCode, object hashCodeSource)
		{
			int sourceHashCode = GetHashCode(hashCodeSource);
			int newHashValue = AddValue(hashCode._value, sourceHashCode);
			return new HashCode(newHashValue);
		}
		/// <summary>
		/// Implicit cast operator to int.
		/// </summary>
		/// <param name="hashCode">Hash code to convert.</param>
		public static implicit operator int(HashCode hashCode) => hashCode._value;
	}
