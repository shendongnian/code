    @using System.Web.UI.WebControls
    @using WebApplication4.Controllers
    @model  WebApplication4.Controllers.EmployeeViewModel
    @{
        ViewBag.Title = "Employee";
    }
    
    <h2>Employee</h2>
    
    @{var listItems = new List<Skills>
      {
          new Skills { Id = 0,Name="Java" },
          new Skills { Id = 1,Name="C++" },
          new Skills { Id = 2,Name="Fortran" }
      };
    }
    @using (Html.BeginForm("AddEmp", "Employee"))
    {
        @Html.TextBoxFor(m => m.Name, new { autofocus = "New Employee" })
        <br/>
        @Html.ListBoxFor(m => m.SelectedSkills,
            new MultiSelectList(listItems, "Id", "Name",@Model.SelectedSkills)
            , new { Multiple = "multiple" })
        <input type="submit" value="Submit" class="submit"/>
    }
