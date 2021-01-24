    var gridObjects = iQueryableObjectList.Select(obj => new 
                {
                    AddedByEmployeeId = obj.AddedByEmployeeId,
                    AddedByEmployeeSignature = obj.AddedByEmployee.Signature,
                    AddedDateTime = obj.Created,
                    DocumentId = obj.DocumentId,
                    ResponsibleEmployeeId = obj.ResponsibleEmployeeId,
                    ResponsibleEmployee = obj.ResponsibleEmployee,
                    Id = obj.Id,
                    IsCompanyWide = obj.IsCompanyWide
                }).ToList() // Saturates the entity data incl. Responsible Employee...
                .Select( obj => new GridObject
    {
                    AddedByEmployeeId = obj.AddedByEmployeeId,
                    AddedByEmployeeSignature = obj.AddedByEmployee.Signature,
                    AddedDateTime = obj.Created,
                    DocumentId = obj.DocumentId,
                    ResponsibleEmployeeId = obj.ResponsibleEmployeeId,
                    ResponsibleEmployee = obj.ResponsibleEmployee != null
                      ? obj.ResponsibleEmployee.FirstName + " " + obj.ResponsibleEmployee.LastName 
                      : companyName,
                    Id = obj.Id,
                    IsCompanyWide = obj.IsCompanyWide
                });
