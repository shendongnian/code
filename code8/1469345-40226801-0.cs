                List<string> list = new List<string>();
                for(int i = 1; i <= hello.Length; i++) {
                   list.Add(hello.Substring(0,i));
                }
                 Console.WriteLine(string.Join(", ", list.ToArray()));
