    var mainList = new List<string> { "Reset", "Set", "Test", "Test", "Reset",        "Test", "Test" };
            var lastIndex = mainList.FindLastIndex(x => x.Equals("Reset"));
            var firstList = new List<string>();
            var secondList = new List<string>();
            for (int i = 0; i < mainList.Count - 1; i++)
            {
                if (i < lastIndex)
                {
                    firstList.Add(mainList[i]);
                }
                else
                {
                    secondList.Add(mainList[i]);
                }
            }
