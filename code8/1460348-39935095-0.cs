	public class Room
	{
		[XmlElement("DoorSquare", Type = typeof(Square)), XmlElement("DoorTriangle", Type = typeof(Triangle))]	
		public Shape Door { get; set; }
		
		[XmlElement("WindowSquare", Type = typeof(Square)), XmlElement("WindowTriangle", Type = typeof(Triangle))]	
		public Shape Window { get; set; }
	}
