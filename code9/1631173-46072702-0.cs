    				IntOrderInvoiceCostOut y = null;
    var list = QueryOver.Of<IntOrderInvoiceCostOut>(() => y)
                    .Where(x => x.IntegrationHandleDate == null)
                    .Select(Projections.Distinct(Projections.Property(() => y.Externalid)))
                    .DetachedCriteria;
    				
    									
    var nonPreliminaryOrders = QueryOver.Of<RefImplOrderEntity>()
                 				.Where(Subqueries.PropertyIn(nameof(RefImplOrderEntity.ExternalId), list));
                                  .Select(x => x.ExternalId)
    							.DetachedCriteria
    				
    		
    								
    var finalList = session.QueryOver<IntOrderInvoiceCostOut>()
                   		.Where(Subqueries.PropertyIn(nameof(IntOrderInvoiceCostOut.ExternalId), nonPreliminaryOrders));
                        .List();
