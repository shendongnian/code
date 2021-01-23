    public PatientInformationMap()
    {
            Schema("FormsLibrary");
            Table("PatientInformation");
            Map(x => x.FullName);
            Map(x => x.DateOfBirth);
            Map(x => x.ContactAccount);
    
            HasManyToMany(x => x.Forms)
                .Schema("FormsLibrary")
                .Table("PatientInformationToForms")
                .ParentKeyColumn("PatientInformationID")
                .ChildKeyColumn("FormID")
                .LazyLoad()
                .Cascade.SaveUpdate();
        }
    }
      
     public FormMap()
     {
            Schema("FormsLibrary");
            Table("Form");
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.FileName);
            Map(x => x.MembersOnly);
            Map(x => x.Status);
            Map(x => x.Active);
            Map(x => x.DisplayFileName);
            Map(x => x.LastModified);
            Map(x => x.CreatedDate);
    
            References(x => x.User, "UserID").LazyLoad();
            References(x => x.Site, "SiteID").LazyLoad();
            References(x => x.Category, "CategoryID").Cascade.SaveUpdate().LazyLoad();
    
            HasManyToMany(x => x.PatientInformation)
                .Schema("FormsLibrary")
                .Table("PatientInformationToForms")
                .ParentKeyColumn("FormID")
                .ChildKeyColumn("PatientInformationID")
                .LazyLoad()
                .Cascade.SaveUpdate();
        }
    }
