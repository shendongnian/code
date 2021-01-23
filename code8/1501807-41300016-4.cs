		AutomobileFactory automobileFactory = new AutomobileFactory();
		IJeep jeep = automobileFactory.Create<IJeep>();
		
		jeep.Rename(new JeepRenameArgs());
		
		// or even:
		ICanRename<JeepRenameArgs> jeep2 = automobileFactory.Create<IJeep>() as ICanRename<JeepRenameArgs>;
		jeep2.Rename(new JeepRenameArgs());
