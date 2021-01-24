    [KnownType(typeof(AccountBalanceRequest))]
    [DataContract]
        public class Current_Account_Details
        { 
        string account_creation_date;
        string account_type;
        string branch_sort_code;
        string account_fees;
        string account_balance;
        string over_draft_limit;
        string  account_holder_id;
    
        [DataMember]
        public string Account_Creation_Date
        {
            get { return account_creation_date; }
            set { account_creation_date = value; }
        }
        [DataMember]
        public string Account_Type
        {
            get { return account_type; }
            set { account_type = value; }
        }
        [DataMember]
        public string Branch_Sort_Code
        {
            get { return branch_sort_code; }
            set { branch_sort_code = value; }
        }
        [DataMember]
        public string Account_Fees
        {
            get { return account_fees; }
            set { account_fees = value; }
    
        }
        [DataMember]
        public string Account_Balance
        {
            get { return account_balance; }
            set { account_balance = value; }
    
    
        }
        [DataMember]
        public string Over_Draft_Limit
        {
    
            get { return over_draft_limit; }
            set { over_draft_limit = value; }
    
        }
        [DataMember]
        public string Account_Holder_Id
        {
    
            get { return account_holder_id; }
            set { account_holder_id = value; }
        }
    }
    }
     public class AccountBalanceRequest : Current_Account_Details
        {
            string account_number;
                  public string Account_Number
            {
                get { return account_number; }
                set { account_number = value; }
            }
        }
