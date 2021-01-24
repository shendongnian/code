        public static bool IsGuidInList(IEnumerable<string> guids, string guidToFind)
        {
            Guid guid;
            if (!Guid.TryParse(guidToFind.Trim(), out guid))
                return false;
            return guids.Any(x => { Guid result;
                Guid.TryParse(x, out result);
                return result == guid;
            });
        }
