        [WebMethod]
        public void Select()
        {
            String result = String.Empty;
            List<UserRole> userRoles = new UserRoleController().Select(new UserRole());
            JavaScriptSerializer js = new JavaScriptSerializer();
            result = js.Serialize(userRoles);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(result);
        }
