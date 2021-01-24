    public static class Players
        {
            private static List<player> _players;
            public static List<player> players
            {
                get { return _players; }
                set { _players = value; }
            }
            public static void playergenerator(string myname, System.Drawing.Color myColor)
            {
                if (players == null)
                    players = new List<player>();
                players.Add(new player() { name = myname, color = myColor });
            }
        }
