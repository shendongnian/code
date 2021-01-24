         string Combine(string text, string key, int step)
         {
            var result = "";
            int stepCount = 0;
            for (int i = 0; i < text.Length + key.Length; i++)
            {
                if (i % step == 0)
                {
                    result += key[i / step];
                    stepCount++;
                }
                else
                {
                    result += text[i - stepCount];
                }
            }
            return result;
        }
