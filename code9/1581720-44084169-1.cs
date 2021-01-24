                var firstResult;
                var secondResult;
                var thirdResult;
                var fourthResult;
                int start = 3;
                for (int i = start; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0 :
                            firstResult = remoteFunction("a"); 
                            break;
                        case 1:
                            secondResult = remoteFunction("b", firstResult);
                            break;
                        case 2:
                            thirdResult = remoteFunction("c", secondResult);
                            break;
                        case 3:
                            fourthResult = remoteFunction("d", thirdResult);
                            break;
                    }
                }
