Not sure but if your remove public ViewModelA() { } does it make it ?
    public class ViewModelA
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }
        //public ViewModelA() { }
    }
And remove ModelState.Clear(); too :
    [HttpPost]
    public ActionResult Register(ViewModels.ViewModelA model)
    {
        if (ModelState.IsValid)
        {
            // Do Something
        }
        else
        {
            // Do Something Else
        }
        //ModelState.Clear();
        return View(model);
    }
