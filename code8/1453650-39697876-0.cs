     public BaseController()
        {
            ViewBag.Menu = MenuList();
        }
        private IList<Menu> MenuList()
        {
            var list = Db.Menus.ToList();
            return list;
        } 
