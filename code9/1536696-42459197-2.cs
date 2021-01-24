    public static IndustryType noType; 
    public static IndustryType ironMine, coalMine, aluminiumMine, copperMine, uraniumMine, goldMine; 
    public static IndustryType quarry, oilWell; 
    public static IndustryType farm;
    
    static IndustryTypes() {
        noType = new IndustryType("noType", 0, Color.Red);
        ironMine = new IndustryType("Iron Mine", 50000, Game.color_mine);
        coalMine = new IndustryType("Coal Mine", 40000, Game.color_mine);
        aluminiumMine = new IndustryType("Aluminium Mine", 100000, Game.color_mine);
        copperMine = new IndustryType("Copper Mine", 55000, Game.color_mine);
        uraniumMine = new IndustryType("Uranium Mine", 150000, Game.color_mine);
        goldMine = new IndustryType("Gold Mine", 125000, Game.color_mine);
    
        quarry = new IndustryType("Quarry", 25000, Game.color_mine);
        oilWell = new IndustryType("Oil Well", 110000, Game.color_oil);
        farm = new IndustryType("Farm", 10000, Game.color_farm);
    
    
       allTypes = new [] {
        ironMine, coalMine, aluminiumMine, copperMine, uraniumMine, goldMine,
        quarry, oilWell, farm }; 
    }
