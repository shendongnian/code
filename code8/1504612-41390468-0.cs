    @{
    ViewBag.Title = "ClassesPickGroup"; } @model ClassDeclarationsThsesis.Models.ClassesPickGroupViewModel
    <h2>ClassesPickGroup</h2>
    @foreach (var user in Model.users) {
    if (user.email.Replace(" ", String.Empty) == HttpContext.Current.User.Identity.Name)
    {
        if (user.user_type.Replace(" ", String.Empty) == 3.ToString() || user.user_type.Replace(" ", String.Empty) == 2.ToString())
        {
            using (Html.BeginForm("ClassesPickGroup", "Account", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
            {
                @Html.AntiForgeryToken()
                <h4>Generate summary views</h4>
                <hr />
                @Html.ValidationSummary("", new { @class = "text-danger" })
                <div class="form-group">
                    @{
                        List<SelectListItem> listItems1 = new List<SelectListItem>();
                        foreach (var sub in Model.subjects)
                        {
                            if (sub.name.Replace(" ", String.Empty) == Model.subject_name.Replace(" ", String.Empty))
                            {
                                Model.subject_id = sub.class_id;
                            }
                                foreach (var group in Model.groups)
                               {
                                  if (group.class_id == Model.subject_id)
                                  {
                                    listItems1.Add(new SelectListItem
                                   {
                                      Text = group.name,
                                      Value = group.name,
                                     });
                                  }
                               }
                            }
                        }
                        
                    }
                    @Html.LabelFor(m => m.selected_group, new { @class = "col-md-2 control-label" })
                    <div class="col-md-10">
                        @Html.DropDownListFor(m => m.selected_group, listItems1, new { @class = "form-control" })
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" class="btn btn-default" value="Submit" />
                    </div>
                </div>
                            }
                        }
                        if (user.user_type.Replace(" ", String.Empty) == 1.ToString())
                        {
                            <p>You do not have enough permissions to enter this page. Contact the administrator.</p>
                                }
                            }
                        }
