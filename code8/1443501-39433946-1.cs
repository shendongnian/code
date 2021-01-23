    /// <span class="code-SummaryComment"><summary></span>
    /// Provides a static utility object of methods and properties to interact
    /// with enumerated types.
    /// <span class="code-SummaryComment"></summary></span>
    public static class EnumHelper
    {
       /// <span class="code-SummaryComment"><summary></span>
       /// Gets the <span class="code-SummaryComment"><see cref="DescriptionAttribute" /> of an <see cref="Enum" /></span>
       /// type value.
       /// <span class="code-SummaryComment"></summary></span>
       /// <span class="code-SummaryComment"><param name="value">The <see cref="Enum" /> type value.</param></span>
       /// <span class="code-SummaryComment"><returns>A string containing the text of the</span>
       /// <span class="code-SummaryComment"><see cref="DescriptionAttribute"/>.</returns></span>
       public static string GetDescription(Enum value)
       {
          if (value == null)
          {
             throw new ArgumentNullException("value");
          }
    
          string description = value.ToString();
          FieldInfo fieldInfo = value.GetType().GetField(description);
          EnumDescriptionAttribute[] attributes =
             (EnumDescriptionAttribute[])
           fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
    
          if (attributes != null && attributes.Length > 0)
          {
             description = attributes[0].Description;
          }
          return description;
       }
    
       /// <span class="code-SummaryComment"><summary></span>
       /// Converts the <span class="code-SummaryComment"><see cref="Enum" /> type to an <see cref="IList" /> </span>
       /// compatible object.
       /// <span class="code-SummaryComment"></summary></span>
       /// <span class="code-SummaryComment"><param name="type">The <see cref="Enum"/> type.</param></span>
       /// <span class="code-SummaryComment"><returns>An <see cref="IList"/> containing the enumerated</span>
       /// type value and description.<span class="code-SummaryComment"></returns></span>
       public static IList ToList(Type type)
       {
          if (type == null)
          {
             throw new ArgumentNullException("type");
          }
    
          ArrayList list = new ArrayList();
          Array enumValues = Enum.GetValues(type);
    
          foreach (Enum value in enumValues)
          {
             list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
          }
    
          return list;
       }
    }
