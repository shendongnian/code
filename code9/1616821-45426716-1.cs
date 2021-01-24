     class PharmacyAtrribute
        {
            public string pharmacyName;
            public string pharmacyTown;
            public List<DrugAttribute> drugList = null;
    
            public PharmacyAtrribute(string pharmacyName, string pharmacyTown, List<DrugAttribute> drugList)
            {
                this.pharmacyName = pharmacyName;
                this.pharmacyTown = pharmacyTown;
                this.drugList = new List<DrugAttribute>(drugList);
            }
        }
