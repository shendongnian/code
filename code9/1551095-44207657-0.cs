    public partial class Item : ICommonInterface
    {
        public Expression<Func<Item, bool>> CurrentUserFilter(int userID)
        {
            return item => item.Order.UserID == userID;
        }
    }
