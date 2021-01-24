    <div class="form-group">
        @{  
          WebApplication3.Models.Framework.BBDbModel context = new WebApplication3.Models.Framework.BBDbModel();
          var Drinks = new SelectList(context.Drinks_Category.Select(m => new SelectListItem { Value = m.Id_category.ToString(), Text = m.Name_category.ToString() }) "Value" , "Text");
         }
        @Html.DropDownListFor(m => m.Id_category, Drinks, "Select a category drink")
    </div>
