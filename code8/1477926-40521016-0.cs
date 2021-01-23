       private async void ChangeLagButton_Click(object sender, RoutedEventArgs e)
        {
            var culture = new System.Globalization.CultureInfo("fr-FR");
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            await Task.Delay(100);
            //To refresh the UI without restart the phone
            this.Frame.Navigate(this.GetType());          
        }
