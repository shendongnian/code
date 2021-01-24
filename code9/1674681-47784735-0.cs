            var list = new List<BtnCountViews>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new BtnCountViews() { BtnCount = i, DayOfYear = i, Views = i });
            }
            var last50 = list.Skip(list.Count - 50).ToList();
