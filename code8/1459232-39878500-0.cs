    var newMap = new AddLayerMap()
    {
        MapId = map.MapId,
        MapTitle = map.Title,
        ThemeMaps = new List<AddLayerMapThemeMap>(),
    };
    // Create map
    vmProject.Maps.Add(newMap);
    
    // Loop over all thememaps in map
    foreach (var thememap in map.ThemeMaps.OrderBy(e => e.Order))
    {
        newMap.ThemeMaps.Add(new AddLayerMapThemeMap()
        {
            ThemeMapId = thememap.ThemeMapId,
            ThemeMapTitle = thememap.Title,
        });
    }
