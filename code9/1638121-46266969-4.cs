    @model YourAppName.Models.Department
    @{
        ViewBag.Title = "SampleApp";
    
        List<YourAppName.Models.Department> department = ViewBag.Department; //Call the ViewBag in the view
    }
    
    <select name="Department" id="Departments" class="form-control">
      <option value="0">--Please Select Department--</option>
          @foreach (var item in department) //Loop through the department to get department details
          {
            <option value="@item.DepartmentID">@item.Code</option>
          }
    </select>
