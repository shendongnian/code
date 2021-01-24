        <Grid>
            <MediaElement Name="videoMediaElement" AreTransportControlsEnabled="True" Stretch="Fill"  MediaOpened="videoMediaElement_MediaOpened" CurrentStateChanged="Media_State_Changed" >
                <MediaElement.TransportControls>
                    <MediaTransportControls Background="Red" Foreground="White" IsStopButtonVisible="True" IsStopEnabled="True" IsTextScaleFactorEnabled="True" IsPlaybackRateEnabled="True" IsPlaybackRateButtonVisible="True" IsFastForwardButtonVisible="True" IsFastForwardEnabled="True" IsFastRewindButtonVisible="True" IsFastRewindEnabled="True" />
                </MediaElement.TransportControls>
            </MediaElement>
            <TextBlock Text="asdf" Foreground="White" HorizontalAlignment="Center" VerticalAlignment="Center"/>
        </Grid>
