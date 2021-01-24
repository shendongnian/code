	public class PlanilhaCusto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? ParentId { get; set; }
		public decimal Amount { get; set; }
		public decimal Price { get; set; }
		public IEnumerable<PlanilhaCusto> Children { get; set; }
	}
