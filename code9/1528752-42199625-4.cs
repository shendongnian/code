    OrderRequest GetOrderRequestObject()
        {
            var rootObj = new OrderRequest
            {
                orders = new List<Order>()
            };
            var order = new Order
            {
                name = "Order 6 - API",
                eligibility = new Eligibility
                {
                    type = "on",
                    onDates = new List<string>() { "20151204" }
                },
                forceVehicleId = null,
                priority = 2,
                loads = new Loads
                {
                    people = 2
                },
                delivery = new Delivery
                {
                    location = new Location
                    {
                        address = "2001 2nd Ave, Jasper, AL 35501, USA"
                    },
                    timeWindows = new List<TimeWindow>(){
                         new TimeWindow{
                             startSec =43200,
                             endSec=54000
                         }},
                    notes = "Order added via API",
                    serviceTimeSec = 1800,
                    tagsIn = new List<object>(),
                    tagsOut = new List<object>(),
                    customFields = new CustomFields
                    {
                        myCustomField = "custom field content",
                        orderId = "abcd1234"
                    }
                },
            };
            rootObj.orders.Add(order);
            return rootObj;
        }
