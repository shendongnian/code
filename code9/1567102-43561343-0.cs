    <% Html.BeginForm("SaveNotes", "Home", FormMethod.Post); %>
    	@Html.AntiForgeryToken()
    	:
    	:
    	<div class="notesLabel">
    		@Html.LabelFor(model => model.Notes)
    	</div>
    	<div class="notesTextBox">
    		@Html.TextBoxFor(model => model.Notes)
    	</div>
    	:
    	:
    
        <input type="submit" name="submit" value="Save" />
    <% Html.EndForm(); %>
    
    
    public class HomeController : Controller  
    {
    	:
    	:
    	
    	[HttpPost]
    	[ValidateAntiForgeryToken]
    	public ActionResult SaveNotes(Mission objMission)
    	{
    		//Set the values to view model accordingly and save to DB eventually
    		if (ModelState.IsValid)
    		{
    			db.Missions.Add(objMission);
    			db.SaveChanges();
    			return RedirectToAction("Index");
    		}
    
    		return View(objMission);
    	}
    	
    	:
    	:
    }
