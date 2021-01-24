    public async Task<JsonResult> GetAll(int id)
        {
            using (Context context = new Context())
            {
                var menus = context.GetAll(id);
                List<MenuView> menusView = Mapper.Map<List<Menu>, List<MenuView>>(menus);
                //Solve circular reference on JSONResult
                var result = JsonConvert.SerializeObject(menusView, Formatting.Indented,
                           new JsonSerializerSettings
                           {
                               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                           });
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
