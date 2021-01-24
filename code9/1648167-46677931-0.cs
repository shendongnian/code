        public List<string> Split(string path)
        {
            var folders = path.Split(new[] {"\\", ":\\" }, StringSplitOptions.None);
            var result = new List<string>();
            for (var i = 0; i <= folders.Length - 1; i++)
            {
                var subPath = string.Empty;
                for (var j = 0; j <= i; j++)
                {
                    subPath += folders[j];
                    if (j == 0)
                        subPath += ":\\";
                    else
                        subPath += "\\";
                }
                result.Add(subPath);
            }
            return result;
        }
