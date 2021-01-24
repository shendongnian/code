    public void OnUpdateAvailable(MyBaseDto baseDto, NotificationType type)
    {
        if (type == NotificationType.Chrome)
        {
            // it uses baseDto.IsUpdateAvailable as well as it downcast it 
     to DerivedAdto and uses other properties
            var derivedDto = baseDto as DerivedAdto;
        }
        if (type == NotificationType.Outlook)
        {
            // currently it just uses baseDto.IsUpdateAvailable
        }
    }
