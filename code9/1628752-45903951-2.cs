     // also covers: I've I'm She'll you're you've;
    
            var sen = "Steve's dog is mine 'not yours' I know you'd like'it";
    
            string asString = String.Empty;
    
            List<string> result = new List<string>();
    
            foreach (Match m in Regex.Matches(sen, @"[^' ]+\w+\'([dstm]|ll|ve|re)|\w+"))
            {
                result.Add(m.Value);
            }
    
            asString = String.Join(",", result.ToArray().Where(s => !string.IsNullOrEmpty(s)));
    
            Console.WriteLine(asString);
    
            // Steve's,dog,is,mine,not,yours,I,know,you'd,like,it
