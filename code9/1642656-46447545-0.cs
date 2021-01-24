            List<string> progName = getProgrammingNames();
            List<string> progTimes = getProgrammingTimes();
            if (progName.Count != progTimes.Count)
                throw new Exception("2 list counts are different");
            List<Item> itemList = new List<Item>();
            for (var l_i = 0; l_i < progName.Count; l_i++)
            {
                itemList.Add(new Item()
                {
                    eventName = progName[l_i],
                    performanceTime = progTimes[l_i]
                });
            }
