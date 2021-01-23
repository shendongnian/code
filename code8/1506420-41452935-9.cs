    Dictionary<NotificationEnum, Action> Actions = new Dictionary<NotificationEnum, Action>()
    {
        { NotificationEnum.module_1, () => 
             {
                 // We know we received module 1 notification request
             }
        },
        { NotificationEnum.module_2, () => 
             {
                 // We know we received module 2 notification request
             }
        },
        // and so on
    };
