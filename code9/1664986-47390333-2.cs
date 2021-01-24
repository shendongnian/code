    public class WaxApple // Not inherited from Fruit or Apple
    {
    	public static explicit operator Apple(WaxApple wax)
    	{
    		return new Apple
    		{
    			Edible = false,
    			Colour = Color.Green,
    			KeepsDoctorAtBay = false
    		};
    	}
    }
