    using System.Data.Entity.Infrastructure;
    //....
    
    catch (DbUpdateException e) when ((e?.InnerException?.InnerException as System.Data.SqlClient.SqlException)?.Number == 2601)
    {    
    	this.ModelState.AddModelError("NameOfColumn", "Item with such NameOfColumn already exist");
    	return View("CompanyForm");
    }
    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
    {
    	//your code;
    }
