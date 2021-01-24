    public async Task<List<Order> GetOrdersFromTradeGeckoCount()
    {
    		string orderLimit = base.StorePlugin.Store.OrderLimit.HasValue ? base.StorePlugin.Store.OrderLimit.Value.ToString() : "250";
    		string filters = string.Format("?status=finalized&limit={0}", orderLimit);
    		HttpResponseMessage response = _requestHelper.GetHttpResponse("orders" + filters);
    		var tgOrders = GetOrdersResponse(response);
    		//Async Convert and Save Order
    		await ConvertToORouterOrdersAsync(tgOrders).ConfigureAwait(false);
    		return ConvertToORouterOrdersCount(tgOrders);
    }
    public Task ConvertToORouterOrdersAsync(List<TGOrder> tgOrders)
    {
    	return Task.Run(() =>
    	{
    		var orderMgr = new OrderDAC();
    		var orders = new List<Order>(tgOrders.Count());
    		foreach (TGOrder tgOrder in tgOrders)
    		{
    			try
    			{
    				var order = new Order();
    				var orderId = TryConvertInt64(CleanUpOrderId(tgOrder.order_number));
    
    				if (orderId == null) continue;
    
    				var tempOrderId = string.Format("{0}{1}", base.StoreId, orderId.Value);
    				order.OrderId = TryConvertInt64(tempOrderId).Value;
    				order.StoreOrderId = tgOrder.id.ToString();
    				order.WarehouseOrderId = tgOrder.order_number;
    
    				var orderFromDb = await orderMgr.GetOrder(order.OrderId, base.StoreId);
    				if (orderFromDb != null) continue; // make sure we only import new order(i.e. doesn't exists in database)
    
    				// shipping address
    				var tgShippingAddress = GetAddress(tgOrder.shipping_address_id);
    				if (tgShippingAddress == null) continue;
    
    				order.ShipFirstName = tgShippingAddress.first_name;
    				order.ShipLastName = tgShippingAddress.last_name;
    				order.ShipCompanyName = tgShippingAddress.company_name;
    				order.ShipAddress1 = tgShippingAddress.address1;
    				order.ShipAddress2 = tgShippingAddress.address2;
    				order.ShipCity = tgShippingAddress.suburb;
    				order.ShipState = tgShippingAddress.state;
    				order.ShipPostalCode = tgShippingAddress.zip_code;
    				order.ShipCountry = tgShippingAddress.country;
    				order.ShipPhoneNumber = tgShippingAddress.phone_number;
    
    				order.CustomerEmail = tgOrder.email;
    
    				// billing address
    				var tgBillingAddress = GetAddress(tgOrder.billing_address_id);
    				if (tgBillingAddress == null) continue;
    
    				// line items
    				var lineItems = GetOrderLineItems(tgOrder.id);
    				foreach (TGOrderLineItem lineItem in lineItems)
    				{
    					var ol = new OrderLine();
    					if (lineItem.variant_id.HasValue)
    					{
    						var variant = GetVariant(lineItem.variant_id.Value);
    						if (variant == null) continue;
    						ol.ProductName = variant.product_name;
    						ol.SKU = variant.sku;
    						ol.ThreePLSKU = ol.SKU;
    						ol.Qty = Convert.ToInt16(TryGetDecimal(lineItem.quantity));
    						ol.OrderId = order.OrderId;
    						ol.Price = TryGetDecimal(lineItem.price);
    						ol.SubTotal = (ol.Qty * ol.Price);
    						ol.StoreOrderLineId = Convert.ToString(lineItem.id);
    						order.OrderLines.Add(ol);
    					}
    				}
    				var validator = new Validator(base.Task);
    				if (validator.IsValidOrder(order))
    				{
    					orderMgr.Add(order);
    				}
    			}
    			catch (Exception ex)
    			{
    				AppendError(ex.Message);
    			}
    		}
    	});
    }
