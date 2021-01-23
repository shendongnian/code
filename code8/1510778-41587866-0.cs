    foreach (var entity in context.EmployeeMaster.Where(em => string.IsNullOrEmpty(em.EmployeeNo))
    {
        var idStr = "0000000" + entity.Id.ToString();
        entity.EmployeeNo = entity.Prefix + idStr.SubString(idStr.Length - 7);
    }
    context.SaveChanges();
