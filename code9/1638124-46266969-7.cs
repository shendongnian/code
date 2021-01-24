    @model List<YourAppName.Models.Department>
    @{
        ViewBag.Title = "SampleApp";
    }
    
    <select name="Department" id="Departments" class="form-control">
      <option value="0">--Please Select Department--</option>
          @foreach (var item in Model) //Loop through the department to get department details
          {
            <option value="@item.DepartmentID">@item.Code</option>
          }
    </select>
