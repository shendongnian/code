    Dictionary<string, string> expectDic = new Dictionary<string, string>();
            for (int i = 0; i < tempList.Count; i++)
            {
                Dictionary<string, string> onedic = tempList[i];
                while (onedic.Values.ToList().Where(x => x.Contains("A_")).FirstOrDefault() != null)
                {
                    expectDic.Add(onedic.Select(x => x.Value).Where(x => x.Contains("A_") && !expectDic.Keys.Contains(x)).First(), onedic.Select(x => x.Value).Where(x => x.Contains("B_") && !expectDic.Values.Contains(x)).First());
                    onedic.Remove(onedic.Select(x => x.Key).Where(x => x.Contains("A_")).FirstOrDefault());
                    onedic.Remove(onedic.Select(x => x.Key).Where(x => x.Contains("B_")).FirstOrDefault());
                }
            }
