        public void DeleteMenu(int id)
        {
            this.RecursiveDeleteMenu(id);
            this.db.SaveChanges();
        }
        public void RecursiveDeleteMenu(int id)
        {
            var item = this.db.Menus.Single(x => x.Id == id);
            //DELETE FOREIGN KEYS
            //MenuLanguageSet
            var languages = from listLanguages in this.db.MenuLanguageSet
                            where listLanguages.idMenu == id
                            select listLanguages;
            foreach (var itemLanguages in languages)
            {
                this.db.MenuLanguageSet.Remove(itemLanguages);
            }
            //Accesses
            var accesses = from listAccesses in this.db.Accesses
                           where listAccesses.menuId == id
                           select listAccesses;
            foreach (var itemAccesses in accesses)
            {
                this.db.Accesses.Remove(itemAccesses);
            }
            //DELETE CHILD
            //Menus
            var menusChild = from listmenus in this.db.Menus
                             where listmenus.parentId == id
                             select listmenus;
            foreach (var child in menusChild)
            {
                RecursiveDeleteMenu(child.Id);
            }
            //delete parent
            this.db.Menus.Remove(item);
        }
