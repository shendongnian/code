    public static class GeneralExtionsions
    {
        //the white space chars valid as separators between every two css class names
        static readonly char[] spaceChars = new char[] { ' ', '\t', '\r', '\n', '\f' };
        //static readonly char[] spaceChars = new char[] { ' ', '\t', '\r', '\n', '\f' };
        /// <summary> Adds or updates the specified css class to list of classes of this TagHelperOutput.</summary>
        public static void AddCssClass(this TagHelperOutput output, string newClass)
        {
            //get current class value:
            string curClass = output.Attributes.FirstOrDefault(a => a.Name == "class")?.Value?.ToString();
            //check if curClass already contains newClass => nothing to do
            if (string.IsNullOrWhiteSpace(newClass) ||
                string.Equals(curClass, newClass, StringComparison.OrdinalIgnoreCase) ||
                curClass.Split(spaceChars, StringSplitOptions.RemoveEmptyEntries).Contains(newClass, StringComparer.OrdinalIgnoreCase)
                )
                return;
            //append newClass to current class string
            if (!string.IsNullOrWhiteSpace(curClass))
            {
                newClass = $"{curClass} {newClass}";
            }
            //set new css class value:
            output.Attributes.SetAttribute("class", newClass);
        }
	}
