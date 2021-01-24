    /// <summary>
    /// Regular expression validation attribute with ability to specify options.
    /// </summary>
    /// <remarks>Swagger schema validation fails if you use the (?i:) named group for case insensitive regexes.</remarks>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class RegularExpressionWithOptionsAttribute : RegularExpressionAttribute
    {
        private Regex Regex { get; set; }
        private RegexOptions Options { get; }
        /// <summary>
        /// Constructor that accepts the regular expression pattern
        /// </summary>
        /// <param name="pattern">The regular expression to use.  It cannot be null.</param>
        /// <param name="options">The options to use for the regular expression.</param>
        public RegularExpressionWithOptionsAttribute(string pattern, RegexOptions options)
            : base(pattern)
        {
            Options = options;
        }
        /// <summary>
        /// Override of <see cref="ValidationAttribute.IsValid(object)"/>
        /// </summary>
        /// <remarks>This override performs the specific regular expression matching of the given <paramref name="value"/></remarks>
        /// <param name="value">The value to test for validity.</param>
        /// <returns><c>true</c> if the given value matches the current regular expression pattern</returns>
        /// <exception cref="InvalidOperationException"> is thrown if the current attribute is ill-formed.</exception>
        /// <exception cref="ArgumentException"> is thrown if the <see cref="Pattern"/> is not a valid regular expression.</exception>
        public override bool IsValid(object value)
        {
            SetupRegex();
            // Convert the value to a string
            var stringValue = Convert.ToString(value, CultureInfo.CurrentCulture);
            // Automatically pass if value is null or empty. RequiredAttribute should be used to assert a value is not empty.
            if (string.IsNullOrEmpty(stringValue))
            {
                return true;
            }
            var match = Regex.Match(stringValue);
            // We are looking for an exact match, not just a search hit. This matches what
            // the RegularExpressionValidator control does
            return (match.Success && match.Index == 0 && match.Length == stringValue.Length);
        }
        /// <summary>
        /// Sets up the <see cref="Regex"/> property from the <see cref="Pattern"/> property.
        /// </summary>
        /// <exception cref="ArgumentException"> is thrown if the current <see cref="Pattern"/> cannot be parsed</exception>
        /// <exception cref="InvalidOperationException"> is thrown if the current attribute is ill-formed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> thrown if <see cref="MatchTimeoutInMilliseconds" /> is negative (except -1),
        /// zero or greater than approximately 24 days </exception>
        private void SetupRegex()
        {
            if (Regex != null)
                return;
            // Ensure base.SetupRegex is called, to check for empty pattern and setup timeout.
            base.IsValid(null);
            Regex = MatchTimeoutInMilliseconds == -1
                ? new Regex(Pattern, Options)
                : Regex = new Regex(Pattern, Options, TimeSpan.FromMilliseconds(MatchTimeoutInMilliseconds));
        }
    }
