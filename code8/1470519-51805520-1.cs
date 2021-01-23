    public static class GeneralExtionsions
    {
        //the white space chars valid as separators between every two css class names
        static readonly char[] spaceChars = new char[] { ' ', '\t', '\r', '\n', '\f' };
        /// <summary> Adds or updates the specified css class to list of classes of this TagHelperOutput.</summary>
        public static void AddCssClass(this TagHelperOutput output, string newClass)
        {
            //get current class value:
            string curClass = output.Attributes["class"]?.Value?.ToString(); //output.Attributes.FirstOrDefault(a => a.Name == "class")?.Value?.ToString();
            //check if newClass is null or equal to current class, nothing to do
            if (string.IsNullOrWhiteSpace(newClass) || string.Equals(curClass, newClass, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            //append newClass to end of curClass if curClass is not null and does not already contain newClass:
            if (!string.IsNullOrWhiteSpace(curClass) 
                && curClass.Split(spaceChars, StringSplitOptions.RemoveEmptyEntries).Contains(newClass, StringComparer.OrdinalIgnoreCase)
                )
            {
                newClass = $"{curClass} {newClass}";
            }
            //set new css class value:
            output.Attributes.SetAttribute("class", newClass);
        }
	}
