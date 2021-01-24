    {
	return new ObservableCollection<SelectableViewModel>
		{
			new SelectableViewModel
			{
				Code = 'E',
				Name = YourResourcesProject.Resources.Erase,
				Description = YourResourcesProject.Resources.EraseTheMCUChipByPage
			},
			new SelectableViewModel
			{
				Code = 'D',
				Name = YourResourcesProject.Resources.Detect,
				Description = YourResourcesProject.Resources.DetectTheMCUFlash
			},
			new SelectableViewModel
			{
				Code = 'P',
				Name = YourResourcesProject.Resources.Programming,
				Description = YourResourcesProject.Resources.ProgrammingTheMCUChipByHexFile
			},
			new SelectableViewModel
			{
				Code = 'V',
				Name = YourResourcesProject.Resources.Verify,
				Description = YourResourcesProject.Resources.VerifyTheDowningCode
			},
			new SelectableViewModel
			{
				Code ='L',
				Name = YourResourcesProject.Resources.Lock,
				Description = YourResourcesProject.Resources.LockTheCodeToProtectTheMCU
			}
		};
}
