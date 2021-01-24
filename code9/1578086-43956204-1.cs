    static class Extensions
    {
        public static int? FindParameterId(this List<AttackStyle> values, string actionStyleAlias)
        {
            return values.FirstOrDefault(x => x.ActionStyleAlias == actionStyleAlias)?.ParameterID;
        }
    }
