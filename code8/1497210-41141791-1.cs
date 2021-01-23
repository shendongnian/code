    public class Menu
    {
        //Other Memebrs
        
        public IEnumerable<Menu> ActiveMenus
        {
            get
            {
                return Childeren?.Where(s => !s.IsDeleted);
            }
        }
    }
