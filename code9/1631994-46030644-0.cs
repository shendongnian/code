           string sentence = "Employee name is [{#john#}], works for [{#ABC BANK#}], 
            [{#Houston#}]";
            string pattern = @"\[\{\#(.*?)\#\}\]";
            foreach (Match match in Regex.Matches(sentence, pattern))
            {
                if (match.Success && match.Groups.Count > 0)
                {
                    var text = match.Groups[1].Value;
                    Console.WriteLine(text);
                }
            }
            Console.ReadLine();
