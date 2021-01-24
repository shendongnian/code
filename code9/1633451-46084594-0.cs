    List<Order> matchingOrders = xyzContext.Orders.Where(
                    o => o.FacilityId == facility.MasterFacilityId
                   && rxNumberList.Contains(o.RxNumber)
                   && o.OrderEvents.All(oe => oe.EventType.Code != EventTypeCode.Delivered)
                   &&  o.OrderEvents.Any(oe.EventType.Code == EventTypeCode.Ordered)).ToList();
