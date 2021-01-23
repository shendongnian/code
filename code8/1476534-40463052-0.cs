    public interface IMenuBuilder
    {
        IMenuBuilder AddLeaf(string name);
        IMenuBuilder AddBranch(string name);
        IMenuBuilder Build();
    }
    public class MenuBuilder : IMenuBuilder
    {
        private IMenuBuilder menuBuilder;
        private ISubMenuHolder menu;
        /// <summary>
        /// Create a new menu with specified root item
        /// </summary>
        public MenuBuilder(string rootName)
        {
            this.menuBuilder = null;
            this.menu = new RootMenu { Name = rootName };
        }
        /// <summary>
        /// Create a new sub menu with specified parents
        /// </summary>
        public MenuBuilder(IMenuBuilder parentBuilder, ISubMenuHolder menu)
        {
            this.menuBuilder = parentBuilder;
            this.menu = menu;
        }
        public IMenuBuilder AddLeaf(string name)
        {
            var leafMenu = new LeafMenu { Name = name };
            leafMenu.ParentId = menu.Id;
            menu.AddSubMenu(leafMenu);
            return this;
        }
        public IMenuBuilder AddBranch(string name)
        {
            var branchMenu = new BranchMenu { Name = name };
            branchMenu.ParentId = menu.Id;
            menu.AddSubMenu(branchMenu);
            return new MenuBuilder(this, branchMenu);
        }
        public IMenuBuilder Build()
        {
            return menuBuilder;
        }
    }
