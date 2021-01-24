	from p in dbContext.Product
	select new
	{
		p.ID,
		p.Name,
		p.Description,
		MinDeliveryDate = (DateTime?)dbContext.Order
		                                      .Where(o => o.ProductID == p.ID)
											  .Min(o => o.DeliveryDate)
	}
