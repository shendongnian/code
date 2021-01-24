    public partial class MyService : ServiceBase
    {
        private void SchedulerCallback()
        {
            using (var myContext = new MyContext())
            {
                var UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(MyContext));
                var users = (from u in myContext.Users where u.Status = StatusFlag.PlaceOrder select u.User).ToList();
                foreach (var user in users)
                {
                    myContext.Order.Add(new MyOrder());
                    myContext.Order.User = user;
                    OrderTransaction transaction = new OrderTransaction();
                    order.Transactions = new List<OrderTransaction>();
                    order.Transactions.Add(transaction);
                    user.Status = StatusFlag.OrderPlaced;
                }
                try
                {
                    myContext.SaveChanges();
                }
                catch (Exception e)
                {
                    Logger.LogError("Exception", e);
                }
            }
        }   
    } 
