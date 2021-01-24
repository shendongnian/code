                var content = "11  blabalba, balbalba balballbal  baba";
    
                var splitContent = content.Split(' ');
    
                splitContent[1] = string.Join(" ", splitContent.Skip(1).Take(splitContent.Length - 1).ToArray());
    
                splitContent = splitContent.Take(2).ToArray();
