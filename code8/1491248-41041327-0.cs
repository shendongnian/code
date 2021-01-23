	public class OurCompanyEtaToCustomerObjectsConvertor : ITypeConverter<Convertor.Model.OurCompany.Eta.OurCompany_ETA, Eta.OurCompany_ETA[]>
	{
		public Customer.Model.Eta.OurCompany_ETA[] Convert(Convertor.Model.OurCompany.Eta.OurCompany_ETA source, Customer.Model.Eta.OurCompany_ETA[] destination, ResolutionContext context)
		{
			destination = new Eta.OurCompany_ETA[0];
			if (source != null)
			{
				if (source.SHIPMENTS != null)
				{
					foreach (var OurCompanyEtashipment in source.SHIPMENTS)
					{
						var CustomerModel = new Customer.Model.Eta.OurCompany_ETA();
						//Other stuff....
						destination = destination.Concat(new[] {CustomerModel}).ToArray();
					}
				}						
			}
			return destination;
		}
	}
