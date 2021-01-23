    @model Project.Models.ViewModel
    
    <div class="container">
        @if (Model.Thing != null)
        {
            var isOffice = thing as Office;
            if (isOffice != null)
            {
                    <!--Display Office-->
            }
            else
            {
                var isComputer = thing as Computer;
                if (isComputer != null)
                {
                        <!--Display Office-->
                }
                else
                {
                    var isMonitor = thing as Monitor;
                    if (isMonitor != null)
                    {
                            <!--Display Office-->
                    }
                }
            }
        }
    
        @Html.Action("_OCMList", "Home");
    </div>
