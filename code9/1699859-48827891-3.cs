    class NamedServiceDescriptor
    {
        public NamedServiceDescriptor(string name, Type serviceType)
        {
            this.Name = name;
            this.ServiceType = serviceType;
        }
        public string Name { get; private set; }
        public Type ServiceType { get; private set; }
        public override bool Equals(object obj)
        {
            if (!(obj is NamedServiceDescriptor))
                return false;
            var other = (NamedServiceDescriptor)obj;
            return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) &&
                ServiceType.Equals(other.ServiceType);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ 
                ServiceType.GetHashCode();
        }
    }
