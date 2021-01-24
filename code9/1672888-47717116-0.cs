    class DictionaryMapper : ISourceToDestinationNameMapper {
        public Dictionary<string, string> Map { get; set; }
        public MemberInfo GetMatchingMemberInfo(IGetTypeInfoMembers getTypeInfoMembers, TypeDetails typeInfo, Type destType, Type destMemberType, string nameToSearch) {
            if (Map == null || !Map.ContainsKey(nameToSearch))
                return null;
            // map properties using Map dictionary
            return typeInfo.DestinationMemberNames
                .Where(c => c.Member.Name == Map[nameToSearch])
                .Select(c => c.Member)
                .FirstOrDefault();
        }
    }
