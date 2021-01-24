        @model dynamic
    
        @using (Html.BeginForm("SubmitActionName", "ControllerName")
         {
         <div class="table-responsive">
          <table>
              @if (Model != null)
                  {
                     foreach (var row in Model)
                      {
     
                      }
                  }
          </table>
    
        </div>
        }
