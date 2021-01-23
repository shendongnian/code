    int numberOf = parsedCards.Count
     for (var i = 0; i < numberOf; i++)
            {
                //var parsedCard = parsedCards[i];
    			int noOf2 = parsedCard[i].Functions.Count()
                for (var j = 0; j < noOf2; j++)
                {
                    var function = parsedCard[i].Functions[j];
    				
    				int = function.Groups.Count();
                    for (var k = 0; k < noOfGroups; k++)
                    {
                        var group = function.Groups[k];
    					int noOfVars = group.ParseResult.Variables.Count();
                        for (var l = 0; l < noOfVars; l++)
                        {
                            var variable = group.ParseResult.Variables[l];
                            if (variable.Name.Contains("TCC#"))
                            {
                                //variable.Type = VariableType.Text;
                                Debug.WriteLine($"Need to change variable at [{i}][{j}][{k}][{l}]");
                            }
                        }
                    }
                }
            }
