    class Product
    {
        public override bool Equals(object other)
        {
            var p = other as Product;
            if (p == null) return false;
            return this.Name == p.Name && this.Address == p.Address && this.Amount == p.Amount;
        }
    }
