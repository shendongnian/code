        public static bool IsGuidInList(List<string> guids, string guidToFind)
        {
            Guid guid;
            if (!Guid.TryParse(guidToFind.Trim(), out guid))
                return false;
            return
                guids
                    .Select(x =>
                    {
                        Guid result;
                        return Guid.TryParse(x, out result) ? (Guid?)result : null;
                    })
                    .Where(x => x.HasValue)
                    .Any(x => x.Value == guid);
        }
