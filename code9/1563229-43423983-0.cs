    /* SettingsCollection omitted, but trivially implementable using
       Dictionary<string, string>, NameValueCollection,
       List<KeyValuePair<string, string>>, whatever. */
    SettingsCollection GetAllSettings()
    {
         return new SettingsCollection
         {
             { nameof(this.DefaultStatus     ), this.DefaultStatus                         },
             { nameof(this.ConnectionString  ), this.ConnectionString                      },
             { nameof(this.TargetSystem      ), this.TargetSystem.ToString("G")            },
             { nameof(this.ThemeBase         ), this.ThemeBase                             },
             { nameof(this.ThemeAccent       ), this.ThemeAccent                           },
             { nameof(this.ShowSettingsButton), this.ShowSettingsButton ? "true" : "false" },
             { nameof(this.ShowActionsColumn ), this.ShowActionsColumn  ? "true" : "false" },
             { nameof(this.LastNameFirst     ), this.LastNameFirst      ? "true" : "false" },
             { nameof(this.TitleCaseCustomers), this.TitleCaseCustomers ? "true" : "false" },
             { nameof(this.TitleCaseVehicles ), this.TitleCaseVehicles  ? "true" : "false" },
             { nameof(this.CheckForUpdates   ), this.CheckForUpdates    ? "true" : "false" }
         };
    }
    public async Task Export(String fileName)
    {
        using( StreamWriter wtr = new StreamWriter( fileName, append: false ) )
            foreach (var setting in GetAllSettings())
                await ExportSetting( wtr, setting.Key, setting.Value ).ConfigureAwait(false);
    }
