    string a = "Hello!ReturnHowspaceyouspacearespacedoing?";
                StringBuilder sb = new StringBuilder(a);
                sb.Replace("Return", Environment.NewLine).Replace("space", " ");
                
                Console.WriteLine(sb.ToString());
