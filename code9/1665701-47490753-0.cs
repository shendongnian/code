            char[] periods = {'.', '!', '?'}; // or any other separator you may like
            string      line       = "";
            string      sentence   = "";
            using (StreamReader reader = new StreamReader ("filename.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.IndexOfAny(periods)<0)
                    {
                        sentence += " " + line.Trim(); // increment sentence if there are no periods
                        // do whatever you want with the sentence
                        if (string.IsNullOrEmpty (sentence))
                            process(sentence);
                        continue;
                    }
                    // I'm using StringSplitOptions.None here so we handle lines ending with a period right
                    string[] sentences = line.Split(periods, StringSplitOptions.None);
                    for (int i = 0; i < sentences.Length; i++)
                    {
                        sentence += " " + line.Trim(); // increment sentence if there are no periods
                        // do whatever you want with the sentence
                        if (string.IsNullOrEmpty(sentence))
                            process(sentence);
                        // we don't want to clean on the last piece of sentence as it will continue on the next line
                        if (i < sentences.Length - 1)
                        {
                            sentence = ""; // clean for next sentence
                        }
                    }
                }
                // this step is only required if you might have the last line sentence ending without a period
                // do whatever you want with the sentence
                if (string.IsNullOrEmpty(sentence))
                    process(sentence);
