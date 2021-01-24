    public class MakeList
    {
        private List<Model1> models1;
        public MakeList()
        {
            models1 = new List<Model1>
            {
                new Model1
                {
                    FirstProp = "Overall",
                    SecondProp = new List<String>
                            {
                               "Attack", "Defence", "Strength",
                            "Hitpoints", "Ranged", "Prayer",
                            "Magic", "Cooking", "Woodcutting",
                            "Fletching", "Fishing", "Firemaking",
                            "Crafting", "Smithing", "Mining",
                            "Herblore", "Agility", "Thieving",
                            "Slayer", "Farming", "Runecrafting",
                            "Hunter", "Construction", "Summoning",
                            "Dungeoneering"
                            },
                    ThirdProp = new List<String>
                            {
                             "Duel Tournaments", "Bounty Hunters",
                            "Bounty Hunter Rogues", "Fist of Guthix",
                            "Mobilising Armies", "B.A Attackers",
                            "B.A Defenders", "B.A Healers",
                            "Castle Wars Games", "Conquest"
                            }
            }
    
    
        };
      }
    }
