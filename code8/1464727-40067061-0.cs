                    //use players discord ID number to locate them in playerData, then find users in game name from there
                    bool foundPlayer = false;
                    for (int i = 0; i < playerData.Count / 10 - 1; i++)
                    {
                        if(playerData[i*10+9] == discordID)
                        {
                            Console.WriteLine("Player found in playerData");
                            if (centerPlayers.Contains(playerData[i * 10]))
                            {
                                Console.WriteLine("Player found online on center");
                                foundPlayer = true;
                                //break off user's steam ID from centerPlayers
                                string name = playerData[i * 10]+ ", ";
                                string[] temp = Regex.Split(centerPlayers, name);
                                string tempb = temp[1];
                                string[] tempc = tempb.Split(' ');
                                Console.WriteLine("Steam ID:" + tempc[0]);
                                //can give gold here, then break
                            }
                            else if (scorchedPlayers.Contains(playerData[i * 10]))
                            {
                                foundPlayer = true;
                                Console.WriteLine("Player found online on scorched");
                                //break off user's steam ID from centerPlayers
                                //can give gold here, then break
                            }
                            else
                            {
                                foundPlayer = true;
                                Console.WriteLine("Player is not online");
                                break;
                            }
                        }
