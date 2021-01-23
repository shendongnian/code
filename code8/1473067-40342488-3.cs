    // Custom comparer for the Restaurant class
    class RestaurantComparer : IEqualityComparer<Restaurant>
    {
        // Products are equal if their ids and price ranges are equal.
        public bool Equals(Restaurant x, Restaurant y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            //Check whether the properties are equal.
            return x.Id == y.Id && x.PriceRange == y.PriceRange;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public int GetHashCode(Product product)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(product, null)) return 0;
    
            //Get hash code for the Id field.
            int hashId product.Id.GetHashCode();
    
            //Get hash code for the Code field.
            int hashPriceRange = product.PriceRange.GetHashCode();
    
            //Calculate the hash code for the product.
            return hashId ^ hashPriceRange;
        }
    }
