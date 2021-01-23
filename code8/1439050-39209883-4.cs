			bool bKeyExists = false;
			foreach (SettingsProperty settingsProperty in appSettings.Properties)
			{
				if (settingsProperty.Name == _strKey)
				{
					bKeyExists = true;
					break;
				}
			}
