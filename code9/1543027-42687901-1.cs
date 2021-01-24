    using System.Data.Entity.Infrastructure;
    //....
    
    catch (DbUpdateException e) when ((e?.InnerException?.InnerException as System.Data.SqlClient.SqlException)?.Number == 2601)
    {    
    	this.ModelState.AddModelError("NameOfColumn", "Item with such NameOfColumn already exist");
    }
    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
    {
        var error = ex.EntityValidationErrors.First().ValidationErrors.First();
        this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
    }
    return View("CompanyForm");
