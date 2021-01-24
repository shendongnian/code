    <MediaPlayerElement x:Name="Player"
           MaxWidth="400"
           AutoPlay="False"
           AreTransportControlsEnabled="True"  >
         <MediaPlayerElement.TransportControls>
             <MediaTransportControls IsZoomButtonVisible="False" IsZoomEnabled="False"
                             IsPlaybackRateButtonVisible="True"
                                     IsPlaybackRateEnabled="True" 
                                     ThumbnailRequested="ControlsThumbnailRequested" 
                                     IsSeekEnabled="True" />
         </MediaPlayerElement.TransportControls>
    </MediaPlayerElement>
