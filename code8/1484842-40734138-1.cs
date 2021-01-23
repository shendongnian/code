    foreach (GuitarItems gList in itemDetails)
            {
            if (x != 2)
            {
                continue;
            }
                sb.Append(
                    string.Format(
                        @"<div class='guitarItemsDetailsWrapper'>
                            ....
                        </div>", gList.Type, gList.Model, gList.Price, gList.Image2, gList.Description, gList.NeckType,
                        gList.Body, gList.Fretboard, gList.Bridge, gList.NeckPickup, gList.BridgePickup, gList.HardwareColor));
    
            if (x == 2)
            {
                break;
            }
            x++;
           }
