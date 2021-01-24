         public DbResult(Exception exception, ref List<string> exceptionArray)
            {
                this.Exception = exception;
                if(exception.GetType() == typeof(DbUpdateException) && exception.InnerException != null) {
                    if (exception.InnerException.Message.StartsWith("The DELETE statement conflicted with the REFERENCE constraint")) {
                        this.DuplicateKeyError = true;
                        this.DuplicateKeyErrorMessage = "There are other objects related to this object. First delete all the related objects.";
    exceptionArray.Add(this.DuplicateKeyErrorMessage);
                    } else if (exception.InnerException.Message.StartsWith("Violation of PRIMARY KEY constraint")) {
                        this.DuplicateKeyError = true;
                        this.DuplicateKeyErrorMessage = "There is already a row with this key in the database.";
                    } else if (exception.InnerException.Message.StartsWith("Violation of UNIQUE KEY constraint")) {
                        this.DuplicateKeyError = true;
                        this.DuplicateKeyErrorMessage = "There is already a row with this key in the database.";
                    }
                } else if(exception.GetType() == typeof(System.InvalidOperationException) && exception.Message.StartsWith("The association between entity types")) {
                    this.DuplicateKeyError = true;
                    this.DuplicateKeyErrorMessage = "There are other objects related to this object. First delete all the related objects.";
                }
            }
