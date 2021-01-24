        private void SetIsVirtualizing(ListView list, bool value)
        {
            var injector = window.Get<TextBox>("MyItems_IsVirtualizing_Injector");
            injector.Text = value.ToString();
        }
