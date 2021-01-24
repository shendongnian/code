        public class ExceptionModel
        {
            public int Id { set; get; }
            public bool IsApproved { set; get; }
            public DateTime ShiftDate { set; get; }
        } 
        
        public class MainModel  
        {
            public string Comment { set;get;}
            public List<ExceptionModel> lst_Exception { set;get;}
        } 
       //this is get request action method
        public ActionResult Create()
        {
            MainModel model = new MainModel();
            model.lst_Exception = new List<ExceptionModel>()
            {
                new ExceptionModel() {Id = 1,IsApproved = false, ShiftDate = DateTime.Now},
                new ExceptionModel() {Id = 2,IsApproved = false, ShiftDate = DateTime.Now},
                new ExceptionModel() {Id = 3,IsApproved = false, ShiftDate = DateTime.Now}
            };
        
            return View(model);
        }
    
       //this is view for action method
        @model MainModel
        @using(Html.BeginForm())
        {
          <table>
            <thead>
                <tr>
                  <th>Approve</th>
                  <th>Deny</th>
                  <th>Shift Date</th>
                </tr>
            </thead>
            <tbody>
              @for (var item = 0; item < Model.lst_Exception.Count; item++)
                 {
                    <tr>
                      <td>@Html.RadioButtonFor(model=>model.lst_Exception[item].IsApproved, "Approve")</td>
                      <td>@Html.RadioButtonFor(model=>model.lst_Exception[item].IsApproved, "Deny")</td>
                      <td><span>@Model.lst_Exception[item].ShiftDate</span>
                   @Html.HiddenFor(model => model.lst_Exception[item].ShiftDate})
                      </td>
                    </tr>
                 }
            </tbody> 
          </table>
       @Html.TextBoxFor(model=>model.Comment)
       <input type="Submit" value="Submit" />
        }
    
    //this is Post action method
    [HttpPost]
    public ActionResult Create(MainModel model)
    {
      //here you can loop through model.lst_Exception to get the select values 
      //from the view 
    }
