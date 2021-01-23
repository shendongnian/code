	public abstract class GamingEquipment
	{
		public string NameOfGamingEquipments { get; set; }
		public int ResourceId { get; set; }
		public double RentalPrice { get; set; }
		public string DeliveryMode { get; set; }
	}
	public class NonPortable : GamingEquipment
	{
		public int quantityOfCables { get; set; }
		public string TypeOfCable { get; set; }
		public string Accessories { get; set; }
	}
	public class Portable : GamingEquipment
	{
		public string sizeOfScreen { get; set; }
		public int quantityOfCartridges { get; set; }
		public string CartridgeName { get; set; }
		public bool touchScreenFunction { get; set; }
	}
	public class Rootobject
	{
		public List<NonPortable> Non_Portable { get; set; }
		public List<Portable> Portable { get; set; }
	}
