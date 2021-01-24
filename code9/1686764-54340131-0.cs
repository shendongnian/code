     public ActionResult Index(string searching)
    {
     var items = new SelectList(new[] { "CSE", "ECE","EEE","IT","MBA" });
     ViewBag.DEP = items;
      ViewBag.Department = new SelectList(db.Sridevis, "Department", "DEP");
            if (!String.IsNullOrEmpty(searching))
            {
                faculty = faculty.Where( x.Department.StartsWith(search) );
            }
            return View(faculty.ToList());
}
    HTML!
     <div>Department</div>
                                                                <div>
                                                                    @Html.DropDownList("searching", (IEnumerable<SelectListItem>)ViewBag.DEP, "Select Department", new { @class = "form-control" })
                                                                </div>
