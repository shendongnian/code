      [ChildActionOnly]
            public async Task<ActionResult> HomeSection()
            {
                try
                {
                    Home home = new Home();
                    home = await HomePageBLL.GetHomeSection();
                    return View("_HomeSectionPartial", home);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
