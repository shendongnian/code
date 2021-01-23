        public async Task<IEnumerable<KeyValueEntity<string>>> GetAllForGroupAsync(string groupName, string subGroupName)
        {
            return async coursesCollection.AsQueryable()
                 .Where(courseGroup => courseGroup.Group.Value == groupName)
                    .SelectMany(courseGroups => courseGroups.Values)
                        .Where(subGroup => subGroup.GroupKeys != null)
                        .Where(subgroup => subgroup.GroupKeys.Value == subGroupName)
                            .Select(groups => groups.ValueKeys)
                            .FirstAsync();
        }
