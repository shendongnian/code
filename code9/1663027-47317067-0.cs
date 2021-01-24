    return contextProvider
                          .Context
                          .OrderAccounts
                          .Where(orderAccount => listCSRId.Contains(orderAccount.OrderCust.UserId) &&
                                        orderAccount.OrderCust.SubmittedDate >= System.Data.Entity.DbFunctions.TruncateTime(startDate.ToUniversalTime())
                                        && orderAccount.OrderCust.SubmittedDate < startDate.AddDays(1).ToUniversalTime()
                                        && orderAccount.OrderCust.OrderStatusId == (int)OrderStatus.Submitted)
                           .Select(x => new Order {
                               UserId = x.OrderCust.UserId,
                               FacilityCode = x.FacilityCode,
                               GreenFlag = x.GreenFlag ?? false,
                               Payable = x.Payable,
                               OrderCustId = x.OrderCustId
                           })
                          .ToList();
