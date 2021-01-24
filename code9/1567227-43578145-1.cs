        private static void AddVbSetting(Activity activity)
        {
            var settings = new VisualBasicSettings
            {
                ImportReferences =
                {
                    new VisualBasicImportReference
                    {
                        Assembly = typeof(DataObject).Assembly.GetName().Name,
                        Import = typeof(DataObject).Namespace
                    }
                }
            };
            VisualBasic.SetSettings(activity, settings);
        }
