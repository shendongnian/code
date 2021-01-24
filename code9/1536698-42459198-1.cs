    public static class IndustryTypes
    {
        public static IndustryType noType = new IndustryType("noType", 0, Color.Red);
        public static IndustryType ironMine = new IndustryType("Iron Mine", 50000, Game.color_mine);
        public static IndustryType coalMine = new IndustryType("Coal Mine", 40000, Game.color_mine);
        public static IndustryType aluminiumMine = new IndustryType("Aluminium Mine", 100000, Game.color_mine);
        public static IndustryType copperMine = new IndustryType("Copper Mine", 55000, Game.color_mine);
        public static IndustryType uraniumMine = new IndustryType("Uranium Mine", 150000, Game.color_mine);
        public static IndustryType goldMine = new IndustryType("Gold Mine", 125000, Game.color_mine);
        public static IndustryType quarry = new IndustryType("Quarry", 25000, Game.color_mine);
        public static IndustryType oilWell = new IndustryType("Oil Well", 110000, Game.color_oil);
        public static IndustryType farm = new IndustryType("Farm", 10000, Game.color_farm);
    
        public static IndustryType[] allTypes = {
            IndustryTypes.ironMine,
            IndustryTypes.coalMine,
            IndustryTypes.aluminiumMine,
            IndustryTypes.copperMine,
            IndustryTypes.uraniumMine,
            IndustryTypes.goldMine,
            IndustryTypes.quarry,
            IndustryTypes.oilWell,
            IndustryTypes.farm
        };
    }
