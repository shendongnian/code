     Dictionary<string, List<int>> uniqueTagList = new Dictionary<string, List<int>>();
     
    
                foreach (var uniqueTag in uniquetags)
                {
                    List<int> lineNumbers = new List<int>();
                    foreach (var item in data.Select((value, i) => new { i, value }))
                    {
                        var value = item.value;
                        var index = item.i;
    
                        //split data into tags
                        var tags = item.ToString().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
    
                        foreach (var tag in tags)
                        {
                            if (uniqueTag == tag)
                            {
                                lineNumbers.Add(index);
                            }
                        } 
                    }
    
                    //remove all having support threshold.
                    if (lineNumbers.Count > 5)
                    {
                        uniqueTagList.Add(uniqueTag, lineNumbers);
                    }  
                }
