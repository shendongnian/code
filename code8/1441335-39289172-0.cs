     _menuItems = new List<MenuItem>();
           
            var ListMenuPunkte = new LibNHibernate.Model.
                MOD_MenuPunkt(LibNHibernate.Global.SessionManager.
                CreateSession()).Holen();
            foreach (var item in ListMenuPunkte)
            {
                string strac = string.Format("{0}.{1}",
                    item.NamespacePassForm,item.PassFormView);
                _menuItems.Add(new MenuItem(item.Bezeichnung, "", 
                    new Action(() => Open(strac, item.Bezeichnung))));
            }
