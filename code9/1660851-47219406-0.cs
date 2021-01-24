                dynamic param = new JObject();
                if (!String.IsNullOrEmpty(paramsEntity.Country))
                {
                    param.Country = paramsEntity.Country;
                }
                if (!String.IsNullOrEmpty(paramsEntity.CompanyID))
                {
                    param.Company_ID = paramsEntity.CompanyID;
                }
                if (!String.IsNullOrEmpty(paramsEntity.StaffID))
                {
                    param.Staff_ID = paramsEntity.StaffID;
                }
                if (!String.IsNullOrEmpty(paramsEntity.BranchID))
                {
                    param.Branch_ID = paramsEntity.BranchID;
                }
                var match = new BsonDocument
                {
                    { "$match",
                        new BsonDocument { BsonSerializer.Deserialize<BsonDocument>(JsonConvert.SerializeObject(param))
                    }
                };
