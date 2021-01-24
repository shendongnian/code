        // Please, notice "None"
        enum Seasons { None, Winter, Spring, Summer, Fall };
        static void Main(string[] args)
        {
            WhichSeason(3);
        }
        static Seasons WhichSeason(int month)
        {
            if (month >= 1 && month <= 3)
                return Seasons.Winter;
            else if (month >= 4 && month <= 6)
                return Seasons.Spring;
            else if (month >= 7 && month <= 9)
                return Seasons.Summer;
            else if (month >= 10 && month <= 12)
                return Seasons.Fall;
            else
                return Seasons.None;
        }
