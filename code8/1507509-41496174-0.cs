        <CheckBox Content="hello"
                  IsChecked="{x:Bind IsDay()}"/>
        public async Task<bool?> IsDay()
        {
            await Task.Delay(2000);
            return true;
        }
        private async void Invoke_M_IsDay_757602046(int phase)
        {
            global::System.Nullable<global::System.Boolean> result = await this.dataRoot.IsDay();
            if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
            {
                XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ToggleButton_IsChecked(this.obj2, result, null);
            }
        }
