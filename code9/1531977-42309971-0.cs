    mapperMock
        .Setup(m => m.Map<CSF.Data.Web.Employer, CSF.Models.Employer>(It.IsAny<CSF.Data.Web.Employer>()))
        .Returns((CSF.Data.Web.Employer e) => new CSF.Models.Employer { 
            EmployerID = e.EmployerID, 
            EmployerName = e.EmployerName,
            //....other code removed for brevity
        });
