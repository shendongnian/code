        void button_close_MouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (OnTabClosing == null)
            {
                ((TabControl)Parent).Items.Remove(this);
                OnTabClosed?.Invoke(this, EventArgs.Empty);
                return;
            }
            foreach (var subHandler in OnTabClosing.GetInvocationList())
            {
                var cea = new TabButtonClosingEventArgs(AttachedForm);
                OnTabClosing?.Invoke(this, cea);
                if (cea.Cancel) continue;
                ((TabControl)Parent).Items.Remove(this);
                OnTabClosed?.Invoke(this, EventArgs.Empty);
            }
        }
