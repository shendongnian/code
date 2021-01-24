    public class JobContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            // first replace all capital letters with space then letter ("A" => " A"). This might include the first letter, so trim the result.
            string result = Regex.Replace(propertyName, "[A-Z]", x => " " + x.Value).Trim();
            // now replace Number with a hash
            result = result.Replace("Number", "#");
            return result;
        }
    }
