        public override int GetHashCode()
        {
            return (Service.GetHashCode() * ConnectsToService.GetHashCode()).GetHashCode();
        }
        public bool Equals(ConnectingService c1)
        {
            return c1.Service == this.Service && c1.ConnectsToService == this.ConnectsToService;
        }
