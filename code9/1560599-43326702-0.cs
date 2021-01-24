                if (i < 2)
                {
                i+=1;
                //create gk
                p = new Goalkeeper(fname, lname, saves, tackles, assists, goals, minutesplayed, fitness);
            }
                else if (i >= 2 && i < 9)
                {
                i++;
                //create d
                p = new Defender(fname, lname, headerswon, tackles, assists, goals, minutesplayed, fitness);
                }
                else if (i >= 9 && i < 16)
                {
                i++;
                //crete mf
                p = new Midfielder(fname, lname, passsuccessrate, tackles, assists, goals, minutesplayed, fitness);
            }
                else
                {
                i++;
                //create striker
                p = new Striker(fname, lname, shotsontarget, tackles, assists, goals, minutesplayed, fitness);
            }
                return p; //return the randomly generated player
