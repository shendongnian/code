    [System.Runtime.Serialization.DataMemberAttribute()]
    public Account_Status.ServiceReference2.AdditionalDetail[] AdditionalDetail {
        get {
            return this.AdditionalDetailField;
        }
        set {
            if ((object.ReferenceEquals(this.AdditionalDetailField, value) != true)) {
                this.AdditionalDetailField = value;
                this.RaisePropertyChanged("AdditionalDetail");
            }
        }
    }
