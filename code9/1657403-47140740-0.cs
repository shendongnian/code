    Asset asset = new Asset {
        StatusID = 1067,
        Name = "computerName",
        Attributes = new List<CustomAttribute> {
            new CustomAttribute{
                Name ="AssetRole",
                ID=12345,
                Choices = new List<CustomAttributeChoice>{
                    new CustomAttributeChoice{
                        ID=71745,
                        Name="Staff"
                    }
                },
                Value="71745",
                ValueText="Staff",
                ChoicesText="Staff"
            }
        }
    };
