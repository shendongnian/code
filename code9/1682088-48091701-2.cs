    static class CodedFileNameExtensions
    {
        public static CodedFileName Newest(this IEnumerable<CodedFileName> source)
        {
            // TODO: exception if null or source empty
            return source.OrderByDescending(sourceElement => sourceElement.TimePart)
                 .First();
        }
        public static CodedFileName NewestOrDefault(this IEnumerable<CodedFileName> source)
        {
             // TODO: exception if null source
             if (source.Any())
                return source.Newest();
             else
                return null;
        }
        public static IEnumerable<CodedFileName> ExtractNewest(this IEnumerable<CodedFileName> source)
        {
            return groupsSameNamePart = source
                .GroupBy(sourceElement => sourceElement.MainPart)
                .Newest(group => group)
        }
    }
