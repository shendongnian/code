     Dictionary<string, int> wordHolder = new Dictionary<string, int>();
                wordHolder.Add("CEFBA",1);
                wordHolder.Add("ZDFEEG",2);
                wordHolder.Add("TYHRFG", 3);
                wordHolder.Add("FFFFBBDD", 4);
                wordHolder.Add("PCDATTY", 5);
    
                var keysToRemove = new List<string>();
    
                string myLetters = "ABCDEF";
    
                var myLettersArray = myLetters.ToCharArray();
    
                foreach (var keyToCheck in wordHolder)
                {
                    var keyCannotBeCreatedFromLetters = false;
                    var keyArray = keyToCheck.Key.ToCharArray();
    
                    foreach (var letterExists in 
                                from keyLetterToCheck in keyArray 
                                    where !keyCannotBeCreatedFromLetters 
                                        select myLettersArray.Any(a => a == keyLetterToCheck) 
                                            into letterExists 
                                                where !letterExists select letterExists)
                    {
                        keysToRemove.Add(keyToCheck.Key);
                        keyCannotBeCreatedFromLetters = true;
                    }
                }
                foreach (var key in keysToRemove)
                {
                    wordHolder.Remove(key);
                }
