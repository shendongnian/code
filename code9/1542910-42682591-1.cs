    using System;
    
    using StringComparer = System.StringComparer;
    using StringComparison = System.StringComparison;
    
    namespace JDanielSmith.System
    {
    	/// <summary>
    	/// Pass around System.StringComparer and System.StringComparison together.
    	/// Also, provides a base class for generics.
    	/// </summary>
    	public abstract class StringComparerAndComparison
    	{
    		internal StringComparer Comparer { get; }
    		internal StringComparison Comparison { get; }
    		internal StringComparerAndComparison(StringComparer comparer, StringComparison comparison)
    		{
    			if (comparer == null) throw new ArgumentNullException(nameof(comparer));
    
    			Comparer = comparer;
    			Comparison = comparison;
    		}
    	}
    
    	/// <summary>
    	/// Compare strings using culture-sensitive sort rules and the current culture.
    	/// </summary>
    	public sealed class CurrentCulture : StringComparerAndComparison
    	{
    		public CurrentCulture() : base(StringComparer.CurrentCulture, StringComparison.CurrentCulture) { }
    	}
    
    	/// <summary>
    	/// Compare strings using culture-sensitive sort rules, the current culture, and
    	/// ignoring the case of the strings being compared.
    	/// </summary>
    	public sealed class CurrentCultureIgnoreCase : StringComparerAndComparison
    	{
    		public CurrentCultureIgnoreCase() : base(StringComparer.CurrentCultureIgnoreCase, StringComparison.CurrentCultureIgnoreCase) { }
    	}
    
    	/// <summary>
    	/// Compare strings using culture-sensitive sort rules and the invariant culture.
    	/// </summary>
    	public sealed class InvariantCulture : StringComparerAndComparison
    	{
    		public InvariantCulture() : base(StringComparer.InvariantCulture, StringComparison.InvariantCulture) { }
    	}
    
    	/// <summary>
    	/// Compare strings using culture-sensitive sort rules, the invariant culture, and
    	/// ignoring the case of the strings being compared.
    	/// </summary>
    	public sealed class InvariantCultureIgnoreCase : StringComparerAndComparison
    	{
    		public InvariantCultureIgnoreCase() : base(StringComparer.InvariantCultureIgnoreCase, StringComparison.InvariantCultureIgnoreCase) { }
    	}
    
    	/// <summary>
    	/// Compare strings using ordinal sort rules.
    	/// </summary>
    	public sealed class Ordinal : StringComparerAndComparison
    	{
    		public Ordinal() : base(StringComparer.Ordinal, StringComparison.Ordinal) { }
    	}
    
    	/// <summary>
    	/// Compare strings using ordinal sort rules and ignoring the case of the strings
    	/// being compared.
    	/// </summary>
    	public sealed class OrdinalIgnoreCase : StringComparerAndComparison
    	{
    		public OrdinalIgnoreCase() : base(StringComparer.OrdinalIgnoreCase, StringComparison.OrdinalIgnoreCase) { }
    	}
    }
