            string str = "Today is a nice day, and I have been driving a car";
            Regex r = new Regex("[a-zA-Z]+", RegexOptions.IgnoreCase);
            var wordCollection = r.Matches(str).Cast<Match>().Select(m => m.Value).ToList();
            var number = wordCollection.Count % 3;
            if (number == 1)
            {
                wordCollection.RemoveAt(wordCollection.Count - 1);
            }
            else if (number == 2)
            {
                wordCollection.RemoveAt(wordCollection.Count - 1);
                wordCollection.RemoveAt(wordCollection.Count - number - 1);
            }
            var list = new List<string>();
            for (var i = 0; i < wordCollection.Count; i+=3)
            {
                list.Add(string.Format("{0} {1} {2}", wordCollection[i], wordCollection[i + 1], wordCollection[i + 2]));
            }
