     public class PharmacyVM
        {
            public Pharmacy pharmacyProp { get; set; }
            public Address addressProp { get; set; }
            public Company companyProp { get; set; }
            public int CityId { get; set; }
           
            public SelectList CityIdList { get; set; }     
            
            public PharmacyVM()
            {
                pharmacyProp = new Pharmacy();
                addressProp = new Address();
                companyProp = new Company();
                CityIdList =new SelectList(db.Cities, "Id", "Name");
            }
        }
    
        public ActionResult Create()
            { 
                var pharmacyVM = new PharmacyVM();
                return View(pharmacyVM);
            }
    
    @model PharmacyVM
    @using (Html.BeginForm())
    {
        @Html.HiddenFor(m => m.CityId )
    
        <div class="editor-label">
            @Html.LabelFor(m => m.Name)
        </div>
        <div class="editor-field">
            @Html.EditorFor(m => m.Name)
            @Html.ValidationMessageFor(m => m.Name)
        </div> 
    
        <button type="submit">Create</button>
    }
    
           [HttpPost]
            public ActionResult Create(PharmacyVM model)
            {
                int c = model.addressProp
                return View(viewModel);
            }
