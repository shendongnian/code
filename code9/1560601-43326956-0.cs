    private Player GetRandomPlayer(int count)
                {
                    
                        Player p; //create new player
        
                    //calculate various stats using random
                    int tackles = rand.Next(0, 20);
                    int assists = rand.Next(0, 3);
                    int goals = rand.Next(0, 3);
                    int  minutesplayed = rand.Next(0, 90);
                    int saves = rand.Next(0,30);
                    int headerswon = rand.Next(0, 20);
                    int passsuccessrate = rand.Next(0, 100);
                    int shotsontarget = rand.Next(0, 25);
                    string fitness = "Fit";
        
                    //create random player names from the names data declared earlier
                    string fname = firstnames[rand.Next(0, firstnames.Length)];
                    string lname = lastnames[rand.Next(0, lastnames.Length)];
        
                    //2gk, 7d,7m,4 striker
        
                    //create different types of player
        
        
                    
        
        
                        if (count < 2)
                        {
        
                            //create gk
                            p = new Goalkeeper(fname, lname, saves, tackles, assists, goals, minutesplayed, fitness);
        
                        }
                        else if (count < 9)
                        {
        
                            //create d
                            p = new Defender(fname, lname, headerswon, tackles, assists, goals, minutesplayed, fitness);
        
                        }
                        else if (count < 16)
                        {
        
                            //crete mf
                            p = new Midfielder(fname, lname, passsuccessrate, tackles, assists, goals, minutesplayed, fitness);
        
                        }
                        else
                        {
        
                            //create striker
                            p = new Striker(fname, lname, shotsontarget, tackles, assists, goals, minutesplayed, fitness);
        
                        }
        
        
        
                        return p; //return the randomly generated player
                    
                    
                    
    
    
            }
