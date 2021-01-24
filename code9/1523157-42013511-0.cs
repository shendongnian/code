	public class Modelo
	{
		public string nome { get; set; }
		public int codigo { get; set; }
	}
	
	public class Ano
	{
		public string nome { get; set; }
		public string codigo { get; set; }
	}
	
	public class RootObject
	{
		public List<Modelo> modelos { get; set; }
		public List<Ano> anos { get; set; }
	}
