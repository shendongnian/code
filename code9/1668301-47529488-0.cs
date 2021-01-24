    var sb = new StringBuilder();
    DbEntityValidationException validationException = (DbEntityValidationException)exception;
    foreach (var e in validationException.EntityValidationErrors)
    {
        foreach (var err in e.ValidationErrors)
        {
            sb.AppendLine($"Validation Error:{err.ErrorMessage}, Property: {err.PropertyName}");
        }
    }
