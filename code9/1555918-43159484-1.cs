	public class Reservation
	{
		public string Type { get; set; }
		public string Customer { get; set; }
		public string JobNbr { get; set; }
		public bool Delivery { get; set; }
		public bool Pickup { get; set; }
		public string DelInst { get; set; }
		public DateTime StartDate { get; set; }
		public string StartTime { get; set; }
		public DateTime EndDate { get; set; }
		public string EndTime { get; set; }
		public string CustTransactionId { get; set; }
		public EquipmentItem[] EquipmentItems { get; set; }
		public Dictionary<string, string> CustomerFields { get; set; } // only use dictionary here if you can guarantee that you won't have two keys the same in the customerFields. Ideally deserialize to a statically typed class.
	}
	public class EquipmentItem
	{
		public string Equipment { get; set; }
		public string CatID { get; set; }
		public string ClassID { get; set; }
		public string LineSeq { get; set; } // I'm guessing this should be a number in the json and not a string
		public string Quantity { get; set; } // I'm guessing this should be a number in the json and not a string
	}
