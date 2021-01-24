    public Resume(ObservableCollection<CertInfo> certList) {
      //null-checks ommited
      CertList = certlist;
      //more initialization
      userId = 0;
    
    }
    public Resume(IEnumerable<CertInfo> certList) : this (new ObservableCollection(certlist) {
    }
    public Resume() : this(new ObservableCollection<CertInfo>()) {
    }
