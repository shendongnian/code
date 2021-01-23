    <div id="userDetails">
     @* All other user details *@
     @using (Ajax.BeginForm("AddPhone", null, new AjaxOptions()
        {
            HttpMethod = "Post",
            InsertionMode = InsertionMode.Replace,
            UpdateTargetId = "userDetails",           
        }, null))
        {
			@Html.HiddenFor(m => m.UserId)
			<input type="text" id="phone" />
			<select id="phoneType">
				<option value="home">Home</option>
				<option value="cell">Cell</option>
			</select>
			<button type="submit">Add Phone</button>
		}
    </div>
    
    [HttpPost]
    public ActionResult AddPhone(int UserId, string phone, string phoneType)
    {
	//Add phone using userId, phone, & phoneType
	...
	
	//Return view with model (user object) to update page with added phone
	return View("UserView", UserObject);
    }
