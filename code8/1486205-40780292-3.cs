     public sealed class WaterfallDataSource
    {
        private static WaterfallDataSource _WaterfallDataSource = new WaterfallDataSource();
        public static async Task<IEnumerable<WaterfallDataGroup>> GetGroupsAsync()
        {
            var groups = await _WaterfallDataSource.GetWaterfallDataAsync();
            return groups;
        }
        public static async Task<WaterfallDataGroup> GetGroupAsync(string uniqueId)
        {
            var groups = await _WaterfallDataSource.GetWaterfallDataAsync();
            var matches = groups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }
        public static async Task<WaterfallDataItem> GetItemAsync(string uniqueId)
        {
            var groups = await _WaterfallDataSource.GetWaterfallDataAsync();
            var matches = groups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }
        private async Task<ObservableCollection<WaterfallDataGroup>> GetWaterfallDataAsync()
        {
            ObservableCollection<WaterfallDataGroup> Groups = new ObservableCollection<WaterfallDataGroup>();
            Uri dataUri = new Uri("ms-appx:///DataModel/WaterfallData.json");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["Groups"].GetArray();
            foreach (JsonValue groupValue in jsonArray)
            {
                JsonObject groupObject = groupValue.GetObject();
                WaterfallDataGroup group = new WaterfallDataGroup(groupObject["UniqueId"].GetString(),
                                                            groupObject["Title"].GetString(),
                                                            groupObject["ImagePath"].GetString(),
                                                            groupObject["Description"].GetString());
                foreach (JsonValue itemValue in groupObject["Items"].GetArray())
                {
                    JsonObject itemObject = itemValue.GetObject();
                    group.Items.Add(new WaterfallDataItem(itemObject["UniqueId"].GetString(),
                                                       itemObject["Title"].GetString(),
                                                       itemObject["ImagePath"].GetString(),
                                                       itemObject["Description"].GetString(),
                                                       itemObject["Content"].GetString()));
                }
                Groups.Add(group);
            }
            return Groups;
        }
        public static async Task<WaterfallDataGroup> GetGroupByItemAsync(WaterfallDataItem item)
        {
            var groups = await _WaterfallDataSource.GetWaterfallDataAsync();
            foreach (var group in groups)
            {
                var match = group.Items.FirstOrDefault(x => x.UniqueId == item.UniqueId);
                if (match != null)
                    return group;
            }
            return null;
        }
    }
