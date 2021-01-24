    public class IssueTypeResolver : IValueResolver<lstIssueType, IssueType, string>
    {
        public string Resolve(lstIssueType source, IssueType destination, string member, ResolutionContext context)
        {
            var cultureCode = context.Options.Items["CultureCode"].ToString();
            if (source.refResourceType != null && source.refResourceType.Resources != null)
            {
                var cultureOverride = source.refResourceType.Resources.FirstOrDefault(r => r.CultureCode == cultureCode);
                if (cultureOverride != null)
                {
                    return cultureOverride.ResourceText;
                }
            }
            return source.DisplayTitle;
        }
    }
