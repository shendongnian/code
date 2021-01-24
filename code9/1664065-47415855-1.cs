     @using (Html.BeginForm("Bonnen", "Bon",FormMethod.Post)) 
      {
        @foreach (var item in Model)
        {
           <tr>
               <td> @Html.TextBoxFor(model => item.Id)</td>
               <td>@Html.DisplayFor(model =>  item.Date)</td>
               <td>@Html.DisplayFor(model =>  item.Description)</td>
           </tr>
        }
        <input type="submit" value="Details" class="btn btn-info"/>
      }
-------
    [HttpPost]
      public ActionResult Bonnen(int[] Id ,DateTime[] Date,string[] Description)
      {
       return RedirectToAction("Details", "Bon", bon);
      }
