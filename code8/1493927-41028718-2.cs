	public WindowMainViewModel WindowMain => GetInstance<WindowMainViewModel>(true);
	public WindowAboutViewModel WindowAbout => GetInstance<WindowAboutViewModel>(false);
	private static TService GetInstance<TService>(bool singleton)
	{
		return ServiceLocator.Current.GetInstance<TService>(singleton ? null : Guid.NewGuid().ToString());
	}
