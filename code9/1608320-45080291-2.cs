    static string ReverseString(string s)
        {
            var sb = new StringBuilder();
            foreach (var s1 in s.Split(' '))
            {
                var rev = s1.Reverse().ToList();
                char punct;
                if (char.IsPunctuation(punct = rev.First()))
                {
                    rev.RemoveAt(0);
                    rev.Add(punct);
                }
                rev.Add(' ');
                sb.Append(rev.ToArray());
            }
            return sb.ToString();
        }
