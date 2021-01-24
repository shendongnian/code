    StringReader sr = new StringReader(arquivo);
                    while (true)
                    {
                        string linha = sr.ReadLine();
    
                        if (linha != null)
                        {
                            Match action = regexAction.Match(linha);
                            switch (action.Value)
                            {
    
                                case "InitGame":
                                    game = InitGame();
                                    games.ListGames.Add(game);
                                    break;
    
                                case "ClientConnect":
                                    ClientConnect(game, linha);
                                    break;
    
                                case "ClientUserinfoChanged":
                                    ClientUserInfoChanged(game, linha);
                                    break;
    
                                case "Kill":
                                    Kill(game, linha);
                                    break;
    
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
    
                    return games;
                }
                catch (Exception ex)
                {
    
                    throw;
                }
            }
