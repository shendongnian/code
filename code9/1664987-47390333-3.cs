    public class Fruit
    {
    	public Color Colour {get; set;}
    	public bool Edible {get; set;}
    }
    public class Apple : Fruit
    {
        public Apple { Color = Green; Edible = true; KeepsDoctorAtBay = true;}
    	public bool KeepsDoctorAtBay{get; set;}
    }
