            var listA = new List<KeyValuePair<DateTime, int>>()
            {
                new KeyValuePair<DateTime, int>(new DateTime(2017,01,01),15),
                new KeyValuePair<DateTime, int>(new DateTime(2017,01,02),15),
                new KeyValuePair<DateTime, int>(new DateTime(2017, 01, 04), 15),
                new KeyValuePair<DateTime, int>(new DateTime(2017, 01, 05), 15)
            };
            var listB = new List<KeyValuePair<DateTime, int>>()
            {
                new KeyValuePair<DateTime, int>(new DateTime(2017, 01, 01), 10),
                new KeyValuePair<DateTime, int>(new DateTime(2017, 01, 03), 15)
            };
            var listC = new List<KeyValuePair<DateTime, int>>();
            var maxCount = Math.Max(listA.Count, listB.Count);
            for (int i = 0; i < maxCount; i++)
            {
                if (listA.Count < i + 1)
                {
                    listC.Add(new KeyValuePair<DateTime, int>(listB[i].Key,-listB[i].Value));
                    continue;
                }
                if (listB.Count < i + 1)
                {
                    listC.Add(new KeyValuePair<DateTime, int>(listA[i].Key, listA[i].Value));
                    continue;
                }
                if (listA[i].Key == listB[i].Key)
                {
                    int value = listA[i].Value - listB[i].Value;
                    listC.Add(new KeyValuePair<DateTime, int>(listA[i].Key, value));
                }
                else
                {
                    listC.Add(new KeyValuePair<DateTime, int>(listA[i].Key, listA[i].Value));
                    listC.Add(new KeyValuePair<DateTime, int>(listB[i].Key, -listB[i].Value));
                }
            }
