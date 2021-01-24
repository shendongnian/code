    @model BLL.Models.MotorInput
    @{
        ViewBag.Title = "Motors";
        Layout = "~/Views/Shared/_UserLayout.cshtml";
    }
    
        @using (Html.BeginForm())
        {
             @Html.DropDownList("CatID", (SelectList)ViewData["CatID"], "-- Select Category --", new { @class = "form-control" })
        
        
         <input type="submit" value="Create">
        }
