    while (i < 90)
        {
            list.Add(i.ToString());
            if (list.Count == 20)
            {
                List<string> copy = list.ToList();
                Console.WriteLine("List contents when calling: " + copy[0]);
                TList.Add(Task.Run(() => publishDoc(copy)));
                list.Clear();
            }
            i++;
        }
