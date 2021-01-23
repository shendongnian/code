        public class MyAppEntities : DbContext
            {
                public DbSet<PayPal> paypal { get; set; } //Remove this or comment this line
                ...
                ...
               //rest of your properties
        }
