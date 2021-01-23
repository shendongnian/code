    public override System.Web.UI.Control GetControl(NameValueCollection parameters, bool assert)
        {
            var sublayout = new RoleSublayout();
            foreach (string key in parameters.Keys)
            {
                ReflectionUtil.SetProperty(sublayout, key, parameters[key]);
            }
            return sublayout;
        }
