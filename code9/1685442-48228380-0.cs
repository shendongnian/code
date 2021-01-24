	public class RateioSimplesRequestModel
	{
		public List<ItemRateio> ItensRateio { get; private set; }
		public List<ItemMaterial> ItensMaterial { get; private set; }
		public RateioSimplesRequestModel()
		{
			ItensRateio = new List<ItemRateio>();
			ItensMaterial = new List<ItemMaterial>();
		}
	}
