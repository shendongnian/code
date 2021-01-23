    protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MediaElement Video = (MediaElement)Player;
            Video.Source = new Uri(Application.Current.Properties["FilePath"].ToString());
        }
