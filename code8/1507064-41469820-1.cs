    var list  = (
        from B in db.Beneficiaries
        join ben in db.BeneficiaryProjects on B.BeneficiaryId equals ben.BeneficiaryId
        where (ben.CardNeeded == true && ben.ProjectId == temp.ProjectId)
        select new {
            B.BeneficiaryId,
            B.FirstName,
            B.LastName,
            B.IdNumber,
            B.Gender
        }
    ).AsEnumerable()
    .Select(B => new Beneficiary() {
        BeneficiaryId = B.BeneficiaryId,
        FirstName = B.FirstName,
        LastName = B.LastName,
        IdNumber = B.IdNumber,
        Gender = B.Gender
    }).ToList();
