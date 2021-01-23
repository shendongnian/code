    //User is logged in, so display the progress bar and add controls
    tabControl.SelectedIndex = 2; // display the progress bar tab
    private void populateHotel(Hotel hotel)
    {
        List<Room> rooms = hotel.rooms;
        Tile tile;
        tile_wrapper.Children.Clear();
        // Use a count variable to keep track of how many rooms have been processed
        int count = 0;
        foreach (Room room in rooms)
        {
            // Update the value of the progress bar
            progressbar1.Value = count++ * 100 / rooms.Count;
            // Cause the progress bar to refresh
            progressbar1.Refresh();
            sql.insertHotelRoom(room);
            tile = new Tile();
            tile.Title = room.room_num;
            tile.Content = room.name_fa;              
            tile.FontFamily = titleRooms.FontFamily; // titleRooms is a textbox
            tile.TitleFontSize = item1.TitleFontSize; // item1 is an already created tile
            tile.FontSize = item1.FontSize;
            tile_wrapper.Children.Add(tile);
        }
        // Now display the rooms tab
        tabControl.SelectedIndex = 1;
    }
