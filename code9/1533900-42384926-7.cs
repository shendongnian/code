        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Device.OS == TargetPlatform.Android)
            {
                DependencyService.Get<IKeyboardHelper>().ShowKeyboard();
                //EventEditor.Focus();
                MessagingCenter.Subscribe<ReportEventDetailPage>(this, "AndroidFocusEditor", (sender) => {
                    Device.BeginInvokeOnMainThread(async () => {
                        await Task.Run(() => Task.Delay(1));
                        EventEditor.Focus();
                        MessagingCenter.Unsubscribe<ReportEventDetailPage>(this, "AndroidFocusEditor");
                    });
                });
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                EventEditor.Focus();
            }
        }
