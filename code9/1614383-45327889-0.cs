    [DataContract]
    public sealed class RegistrationRequest
    {
        [DataMember(Order = 0, IsRequired = true)]
        public Registration_Header registration_header { get; set; }
        [DataMember(Order = 1, IsRequired = true)]
        public Customer_Details primary_user { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        public StaffDetails partner_attributes { get; set; }
        [DataMember(Order = 3, IsRequired = true)]
        public CustomerAddress primary_residential_address { get; set; }
        public class Registration_Header
        {
            [DataMember(Order = 0, IsRequired = true)]
            public string services_required { get; set; }
            [DataMember(Order = 1, IsRequired = true)]
            public string account_type { get; set; }
            [DataMember(Order = 2, IsRequired = true)]
            public string affiliate_number { get; set; }
        }
        [DataContract]
        public class Customer_Details
        {
            [DataMember(IsRequired = true)]
            public string title { get; set; }
            [DataMember(IsRequired = true)]
            public string first_name { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public string middle_name { get; set; }    
            [DataMember(IsRequired = true)]
            public string last_name { get; set; }
            [DataMember(IsRequired = true)]
            public string email { get; set; }
            [DataMember(IsRequired = true)]
            public string nationality { get; set; }
            [DataMember(IsRequired = true)]
            public string dob { get; set; }
            [DataMember(IsRequired = true)]
            public string occupation { get; set; }
            [DataMember(IsRequired = true)]
            public string residence_country { get; set; }
            [DataMember(IsRequired = true)]
            public string mobile_number { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public string landline_number { get; set; }
            [DataMember(IsRequired = true)]
            public string source { get; set; }
        }
        public class StaffDetails
        {
            [DataMember(IsRequired = true)]
            public string reps_name { get; set; }
            [DataMember(IsRequired = true)]
            public string reps_location { get; set; }
            [DataMember(IsRequired = true)]
            public string customer_id { get; set; }
        }
        public class CustomerAddress
        {
            [DataMember(IsRequired = true)]
            public string postcode { get; set; }
            [DataMember(IsRequired = true)]
            public string street_or_address { get; set; }
            [DataMember(Name = "city", IsRequired = true)]
            public string city { get; set; }
            [DataMember(Name = "country", IsRequired = true)]
            public string country { get; set; }
        }
    }
