    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Net;
    
        [Required, MinLength(4), MaxLength(16)]
        public byte[] IPAddressBytes { get; set; }
    
        [NotMapped]
        public IPAddress IPAddress
        {
            get { return new IPAddress(IPAddressBytes); }
            set { IPAddressBytes = value.GetAddressBytes(); }
        }
