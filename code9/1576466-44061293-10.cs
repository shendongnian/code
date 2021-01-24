    class Vehicle
    {
        public int Id;    
    }
    
    // PrimaryKey="Id" - Id refers to Vehicle.Id, not Product.Id
    [RelationshipLink(BelongsTo=typeof(Product), PrimaryKey="Id", ForeignKey="VehicleId"]
    class Product
    {
        public int Id;
        public int VehicleId;
    }
    
    // PrimaryKey="Id" - Id refers to Product.Id, not Customer.Id
    [RelationshipLink(BelongsTo=typeof(Product), PrimaryKey="Id", ForeignKey="ProductId"]
    class Customer
    {
        public int Id;
        public int ProductId;
    }
