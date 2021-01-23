    /// <span class="code-SummaryComment"><summary></span>
    /// Provides a description for an enumerated type.
    /// <span class="code-SummaryComment"></summary></span>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, 
     AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute :  Attribute
    {
       private string description;
    
       /// <span class="code-SummaryComment"><summary></span>
       /// Gets the description stored in this attribute.
       /// <span class="code-SummaryComment"></summary></span>
       /// <span class="code-SummaryComment"><value>The description stored in the attribute.</value></span>
       public string Description
       {
          get
          {
             return this.description;
          }
       }
    
       /// <span class="code-SummaryComment"><summary></span>
       /// Initializes a new instance of the
       /// <span class="code-SummaryComment"><see cref="EnumDescriptionAttribute"/> class.</span>
       /// <span class="code-SummaryComment"></summary></span>
       /// <span class="code-SummaryComment"><param name="description">The description to store in this attribute.</span>
       /// <span class="code-SummaryComment"></param></span>
       public EnumDescriptionAttribute(string description)
           : base()
       {
           this.description = description;
       }
    }
