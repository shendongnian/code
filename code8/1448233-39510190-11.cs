            var original = "{}[]";
            foreach (var encoding in Encoding.GetEncodings())
            {
                var s = encoding.GetEncoding().GetString(Encoding.UTF8.GetBytes(original));
                if (s == "äüÄÜ")
                {
                    Console.WriteLine(string.Format("Match found for encoding display name {0} (code page {1})", encoding.Name, encoding.CodePage));
                }
            }
