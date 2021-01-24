        [Action("contextAction:")]
        public void contextAction(NSObject sender)
        {
            if (sender is NSMenuItem)
            {
                var nsMenuItem = (NSMenuItem)sender;
                var wrapper = nsMenuItem.RepresentedObject as NSObjectWrapper;
                if (wrapper != null) {
                    var menuItem = wrapper.Context as MenuItem;
                    if (menuItem != null) {
                        menuItem.Command.ExecuteAsync();
                    }
                }
            }
        }
