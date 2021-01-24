        // id in basemodel
    
    
        public string MobileNumber { get; set; }
    
    
        public string Password { get; set; }
    
        public string FullName {get; set;}    
    
        public StatusType Status { get; set; }
    
    
        public string Email { get; set; }
    
    
    
        [ScaffoldColumn(false)]
        public byte[] Key { get; set; }
    
        [ScaffoldColumn(false)]
        public byte[] Iv { get; set; }
    
        [ScaffoldColumn(false)]
        public byte[] Salt { get; set; }
        //Encrypt and Decrypt Properties
        [NotMapped]
        public string EnDecryptedMobileNumber
        {
            //get { return EnDeCryptMethods.AesDecrypt(this.MobileNumber, this.Key, this.Iv); }
            //set { this.MobileNumber = EnDeCryptMethods.AesEncrypt(value, this.Key, this.Iv); }
            get { return MobileNumber; }
            set { MobileNumber = value; }
        }
        [NotMapped]
        public string EnDecryptedPassword
        {
            //get { return EnDeCryptMethods.AesDecrypt(this.Password, this.Key, this.Iv); }
            //set { this.Password = EnDeCryptMethods.AesEncrypt(value, this.Key, this.Iv); }
            get { return this.Password; }
            set { this.Password = value; }
        }
        [NotMapped]
        public string EnDecryptedEmail
        {
            //get { return EnDeCryptMethods.AesDecrypt(this.Email, this.Key, this.Iv); }
            //set { this.Email = EnDeCryptMethods.AesEncrypt(value, this.Key, this.Iv); }
            get { return this.Email; }
            set { this.Email = value; }
        }
    
        //END Encrypt and Decrypt Properties
    
    
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public static string GetEncryptedValue(string value)
        {
            // return ... your Encryption-Code;
         }
    }
