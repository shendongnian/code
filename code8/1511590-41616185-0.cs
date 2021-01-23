        public ActionResult Navbar()
        {
            var model = new NavbarViewModel()
            {
                Administrator = User.IsInRole("Admin"),
                Reporting = User.IsInRole("Reporting")
            };
            return PartialView(model);
        }
        public class NavbarViewModel
        {
            public bool Administrator { get; set; }
            public bool Reporting { get; set; }
        }
