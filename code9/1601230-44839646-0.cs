    var gridObjects = iQueryableObjectList.Select(obj => new GridObject {
                {
                    AddedByEmployeeId = obj.AddedByEmployeeId,
                    AddedByEmployeeSignature = obj.AddedByEmployee.Signature,
                    AddedDateTime = obj.Created,
                    DocumentId = obj.DocumentId,
                    ResponsibleEmployeeId = obj.ResponsibleEmployee.EmployeeId
                    ResponsibleEmployee = obj.ResponsibleEmployee != null ? obj.ReponsibleEmployee.FirstName + " " + obj.ResponsibleEmployee.LastName : companyName,
                    Id = obj.Id,
                    IsCompanyWide = obj.IsCompanyWide
                });
