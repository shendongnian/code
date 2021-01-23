    public void OpenBooks(object sender, EventArgs e)
            {
                switch (Device.OS)
                {
                    case TargetPlatform.iOS:
                        Device.OpenUri(new Uri("itms-books"));
                        break;
                    case TargetPlatform.Android:
                        DependencyService.Get<OpenBookInterface>().openBooks();
                        break;
                }
            }
