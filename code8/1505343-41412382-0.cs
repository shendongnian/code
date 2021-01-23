    private string ReturnTop(IEnumerable<string> current, IEnumerable<string> topList)
        {
            var topMap = topList.Select((value, index) => new {Value = value, Index = index})
                                .ToDictionary(item => item.Value, item => item.Index);
            string minItem = null;
            int minPosition = topMap.Count;
            foreach (var item in current)
            {
                var currentPosition = topMap[item];
                if (currentPosition == 0)
                {
                    return item;
                }
                if (currentPosition < minPosition)
                {
                    minPosition = currentPosition;
                    minItem = item;
                }
            }
            return minItem;
        }
