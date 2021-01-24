    class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PortalItemTagTypeId { get; set; }
        public Tag Clone()
        {
            return new Tag { Id = Id, Name = Name, 
                PortalItemTagTypeId = PortalItemTagTypeId };
        }
    }
