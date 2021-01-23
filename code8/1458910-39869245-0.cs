    /// <summary>
    ///     Represents the various forms of address
    /// </summary>
    public enum CarMake
    {
        [Description("Unknown")]Unknown = -1,
        [Description("Ford Motor Company")] Ford = 1,
        [Description("Nissan Japan")] Nissan = 2,
    }
        /// <summary>
        ///     Returns the value attribute content for an enum member.
        /// </summary>
        /// <param name="aEnumMember">Enumeration member to retrieve the description of.</param>
        /// <returns>Returns the contents of the attribute or null if no attribute found</returns>
        public static object GetValue(this Enum aEnumMember)
        {
            Value userValue = GetAttribute<Value>(aEnumMember);
            return userValue != null ? userValue.Val : null;
        }
        /// <summary>
        ///     Returns the description for an enumeration memnber.
        /// </summary>
        /// <param name="aEnumMember">Enumeration member to return the description of via the Description attribute.</param>
        /// <returns>
        ///     Returns the value of the description attribute if present otherwise the string representation of the enum
        ///     member.
        /// </returns>
        /// <example>string text = CarMake.Ford.GetDescription();</example>
        public static string GetDescription(this Enum aEnumMember)
        {
            Type type = aEnumMember.GetType();
            MemberInfo[] memberInfo = type.GetMember(aEnumMember.ToString());
            if (memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof (DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((DescriptionAttribute) attributes.First()).Description;
                }
            }
            return aEnumMember.ToString();
        }
            /// <summary>
            ///     Constructs a select list where the item desription uses the Description attribute if specified for the member
            ///     or else the name of the member, the value is either the ordinal position in the enum or if specified the Value
            ///     attribute.
            /// </summary>
            /// <param name="aEnumeration">Enumeration to use.</param>
            /// <param name="aSelectedValue">Selected value should the item be selected in the list.</param>
            /// <param name="aIncludeDefaultItem">When true will include aDefaultItemText at the top of the list with a value of null.</param>
            /// <param name="aDefaultItemText"></param>
            /// <returns></returns>
            /// <example>var carSelectList = new CarMake().ToSelectList(CarMake.Ford, true)</example>
            public static SelectList ToSelectList(this Enum aEnumeration, object aSelectedValue = null, bool aIncludeDefaultItem = true, string aDefaultItemText = "(Select)")
            {
                List<SelectListQueryItem<object>> list = (from Enum e in Enum.GetValues(aEnumeration.GetType())
                                                          select new SelectListQueryItem<object>
                                                          {
                                                              Id = e.GetValue() == null ? Enum.Parse(aEnumeration.GetType(), Enum.GetName(aEnumeration.GetType(), e)) : e.GetValue(),
                                                              Name = e.GetDescription()
                                                          }).ToList();
    
                if (aIncludeDefaultItem)
                {
                    list.Insert(0, new SelectListQueryItem<object> {Id = null, Name = aDefaultItemText});
                }
                return new SelectList(list, "ID", "Name", aSelectedValue);
            }
