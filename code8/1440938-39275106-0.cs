        bsSourceAlbum.CurrentChanged += bsSourceAlbum_CurrentChanged;
        void bsSourceAlbum_CurrentChanged(object sender, EventArgs e)
        {
            bsSourceTrack.Clear();
            
            BindingSource SenderSource = (BindingSource)sender;
            
            if (SenderSource.Current != null && SenderSource.Current is Album)
            {
                bsSourceTrack.DataSource = ((Album)((BindingSource)sender).Current).Tracks;
            }
        }
