    public void GetPlaylistByIdAsync_NonExistingPlaylist_ThrowsPlaylistNotFoundException()
    {
        var playlistId = Guid.NewGuid().ToString();
        var manager = PlaylistTargetsFakeFactory.GetPlaylistTargetFusionManager();
        var ex = Assert.ThrowsExceptionAsync<PlaylistNotFoundException>(
                async () =>
                {
                    await manager.GetPlaylistByIdAsync(playlistId);
                }).Result;
        Assert.IsTrue(ex.ErrorCode == ...);
    }
