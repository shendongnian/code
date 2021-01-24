    public static string Method(string sentence)
        {
            var words = sentence.Split(' ');
            string answer = "";
            for (int i = 0; i <= words.Count() - 1; i++)
            {
                var First = words[i].Substring(0, 1);
                var Rest = words[i].Substring(1);
                var Cap = First.ToUpper();
                var low = Rest.ToLower();
                answer += Cap + low;               
            }
            return answer;
        }
