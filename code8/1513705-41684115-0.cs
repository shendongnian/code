    public class LastAccounts
    {
        public string made_up_to { get; set; }
        public string type { get; set; }
    }
    
    public class AccountingReferenceDate
    {
        public string month { get; set; }
        public string day { get; set; }
    }
    
    public class Accounts
    {
        public LastAccounts last_accounts { get; set; }
        public string next_due { get; set; }
        public bool overdue { get; set; }
        public string next_made_up_to { get; set; }
        public AccountingReferenceDate accounting_reference_date { get; set; }
    }
    
    public class RegisteredOfficeAddress
    {
        public string region { get; set; }
        public string locality { get; set; }
        public string address_line_2 { get; set; }
        public string postal_code { get; set; }
        public string address_line_1 { get; set; }
    }
    
    public class PreviousCompanyName
    {
        public string effective_from { get; set; }
        public string name { get; set; }
        public string ceased_on { get; set; }
    }
    
    public class ConfirmationStatement
    {
        public string last_made_up_to { get; set; }
        public string next_made_up_to { get; set; }
        public string next_due { get; set; }
        public bool overdue { get; set; }
    }
    
    public class Links
    {
        public string self { get; set; }
        public string filing_history { get; set; }
        public string officers { get; set; }
        public string charges { get; set; }
    }
    
    public class Company
    {
        public Accounts accounts { get; set; }
        public string company_name { get; set; }
        public bool has_been_liquidated { get; set; }
        public RegisteredOfficeAddress registered_office_address { get; set; }
        public string status { get; set; }
        public string last_full_members_list_date { get; set; }
        public string date_of_creation { get; set; }
        public List<string> sic_codes { get; set; }
        public bool undeliverable_registered_office_address { get; set; }
        public string type { get; set; }
        public string company_number { get; set; }
        public string jurisdiction { get; set; }
        public bool has_insolvency_history { get; set; }
        public string etag { get; set; }
        public string company_status { get; set; }
        public bool has_charges { get; set; }
        public List<PreviousCompanyName> previous_company_names { get; set; }
        public ConfirmationStatement confirmation_statement { get; set; }
        public Links links { get; set; }
        public bool registered_office_is_in_dispute { get; set; }
        public bool can_file { get; set; }
    }
