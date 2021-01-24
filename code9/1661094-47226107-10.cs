    static class CommonExtensions
    {
        public static bool CheckSurName(this Common common)
        {
            JwDistanceSurname jw = _rep.GetJwDistanceSurname(common.String1, common.String2);
            ...
        }
    }
