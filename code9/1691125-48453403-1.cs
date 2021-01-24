    HashSet<string> encounteredActors = new HashSet<string>();    
    // Loops through all lines and writes 
    foreach (var item in newList)
    {
        if (item.Notification.Equals("HELLO"))
        {
            if ( !encounteredActors.Contains( item.Actor ) )
            {
               encounteredActors.Add( item.Actor );
               Console.WriteLine(item.Actor + " " + "ALIVE" + " " + item.MonitorTime + " " + item.Actor + " " + item.Notification + " " + item.Actor2);
            }
        }
        else if(item.Notification.Equals("LOST"))
        {
            if ( !encounteredActors.Contains( item.Actor2 ) )
            {
               encounteredActors.Add( item.Actor2 );
               Console.WriteLine(item.Actor2 + " " + "DEAD" + " " + item.MonitorTime + " " + item.Actor + " " + item.Notification + " " + item.Actor2);
            }
        }
        else if (item.Notification.Equals("FOUND"))
        {
            if ( !encounteredActors.Contains( item.Actor2 ) )
            {
               encounteredActors.Add( item.Actor2 );
               Console.WriteLine(item.Actor2 + " " + "ALIVE" + " " + item.MonitorTime + " " + item.Actor + " " + item.Notification + " " + item.Actor2);
            }
        }
    }
