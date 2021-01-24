    var companyName = "Company";    
    
    var gridObjects = iQueryableObjectList.Select(obj => new GridObject
                {
                    AddedByEmployeeId = obj.AddedByEmployeeId,
                    AddedByEmployeeSignature = obj.AddedByEmployee.Signature,
                    AddedDateTime = obj.Created,
                    DocumentId = obj.DocumentId,
                    ResponsibleEmployeeId = obj.ResponsibleEmployeeId,
                    ResponsibleEmployee = obj.ResponsibleEmployeeId != DBNull.Value ? 
                        obj.ResponsibleEmployee.FirstName + " " + obj.ResponsibleEmployee.LastName :
                        companyName,
                    Id = obj.Id,
                    IsCompanyWide = obj.IsCompanyWide
                });
