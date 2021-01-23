        public class ShopCart
        {
            public class ShopCartPosition
            {
                private int _number;
                public int Number
                {
                    get { return _number; }
                    set { _number = value; }
                }
            }
        }
        public class User
        {
            ShopCart.ShopCartPosition _shopCartPosition;
            public User(ShopCart.ShopCartPosition shopCartPosition)
            {
                _shopCartPosition = shopCartPosition;
            }
            public int GetNumber()
            {
                return _shopCartPosition.Number;
            }
        }
        public static void Main()
        {
            ShopCart.ShopCartPosition pos = new ShopCart.ShopCartPosition();
            pos.Number = 5;
            User user = new User(pos);
            Console.WriteLine(user.GetNumber().ToString());
        }
