        // This is a method of Application class "F10Client".
        // SecondaryViews is a member of this class.
        // In my app, this method is called when the app resumes.
        public async Task<bool> TogglePrivateMaskForAllPages(bool isMask)
        {
            bool retVal = true;
            if (null != ((F10Client)F10Client.Current).SecondaryViews && 0 < ((F10Client)F10Client.Current).SecondaryViews.Count)
            {
                foreach (var view in ((F10Client)F10Client.Current).SecondaryViews)
                {
                    // You should use dispatcher to call the page method.
                    await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        var thePage = (ImagePage)((Frame)Window.Current.Content).Content;
                        // calling the method.
                        thePage.TogglePrivacyMask(isMask);
                    });
                }
            }
            return retVal;
        }
