    private List<Room> insertHotelRooms(Hotel hotel)
    {
        List<Room> rooms = hotel.rooms;
        foreach (Room room in rooms)
        {
            sql.insertHotelRoom(room);
            rooms.Add(room);
        }
        return rooms;
    }
    private void populateHotelTab(List<Room> rooms)
    {
        Tile tile;
        tile_wrapper.Children.Clear();
        foreach (Room room in rooms)
        {
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
