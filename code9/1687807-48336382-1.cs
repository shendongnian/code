    public string GetChildNodeForm(string menuTitle)
    {
        return uow.Repository<MainMenu>().GetAll()
            .FirstOrDefault(x => x.MenuTitle == menuTitle && x.IsVisible == 1)
            ?.FormName?.Trim();
    }
