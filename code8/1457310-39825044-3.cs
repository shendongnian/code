    @model Project.Models.ViewModel
    
    <div class="container">
        @if (Model.Thing != null)
        {
            if (thing is Office office)
            {
                    <!--Display Office-->
            }
            else if (thing is Computer computer)
            {
                    <!--Display Office-->
            }
            else if (thing is Monitor monitor)
            {
                    <!--Display Office-->
            }
         }
    
        @Html.Action("_OCMList", "Home");
    </div>
