        private void DoWork()
        {
            var orders = BuildOrders();
            float? fCost1 = orders.Where(r => r.OrdID == 1).Select(t => t.cost).SingleOrDefault();
            float? fCost2 = orders.Where(r => r.OrdID == 2).Select(t => t.cost).SingleOrDefault();
            float? fCost3 = orders.Where(r => r.OrdID == 3).Select(t => t.cost).SingleOrDefault();
        }
        internal class Order
        {
            public int OrdID { get; set; }
            public float? cost { get; set; }
        }
        private IEnumerable<Order> BuildOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    OrdID = 1,
                    cost = null
                },
                new Order
                {
                    OrdID = 2,
                    cost = 1
                }
            };
        }
