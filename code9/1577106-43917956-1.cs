	public void VerwijderOrder(int id)
	{
		// code not shown has not been altered
		foreach (ProductOrder po in ProductOrder)
		{
			if (po.OrderId == id)
			{
				// ProductOrder.Remove(po);
			}
		}
		ProductOrder.RemoveAll(x => x.OrderId == id);
	}
