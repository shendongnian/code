    public class Customer {
        public virtual Customer ParentCustomer { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        /// <summary>
        /// Exposed foreign key of the <see cref="ParentCustomer "/>.
        /// This is optional (might be null), because not every Customer is grouped into another Customer .
        /// </summary>
        public long? ParentCustomerId { get; set; }
    }
    ModelBuilder.Entity<Customer>()
       .HasMany(x => x.Customers)
       .WithOptional(x => x.ParentCustomer)    // Not all Customers are contained in a parent Customer, therefore this relationship is optional
       .HasForeignKey(x => x.ParentCustomerId)
       .WillCascadeOnDelete(false);            // ON DELETE NO ACTION constraint is necessary or we would introduce multiple cascade paths
