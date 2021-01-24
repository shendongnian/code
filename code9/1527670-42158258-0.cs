    you can skip empty rows..
     var str1 = str.Trim().Split(';')
                    .Where(x => !string.IsNullOrEmpty(x) && x.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries).Any())
                    .Select(x => new CrossReference
                    {
                        TaskType = (string)x.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries)[0],
                        Aid = Convert.ToInt64(x.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries)[1]),
                    }).ToList();
