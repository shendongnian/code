    class SomeView : Form
    {
        void ShowVisualFeedBack()
        {
            ...
        }
        void HideVisualFeedBack()
        {
            ...
        }
        public async Task LoadDataAsync()
        {
            bool result = false;
            this.ShowVisualFeedBack()
            try
            {
                this.itemList = await WebService.Instance.GetData();
                result = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            this.HideVisualFeedBack();
            return result;
        }
    }
