    public string GetChildNodeForm(string menuTitle)
    {
        return uow.Repository<MainMenu>().GetAll()
            .Where(x => x.MenuTitle == menuTitle && x.IsVisible == 1)
            .FirstOrDefault()?.FormName?.Trim();
    }
