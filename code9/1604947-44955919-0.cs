    int index = 0;
    foreach( var item in flightData )
    {
        //get the current values for the vehicle item at this time
        vehicleState = getVehicleStateMethod( item );
        vehicleAlt = getVehicleAltMethod( item );
        vehicleVR = getVehicleVrMethod( item );
        vehicleTime = getVehicleTimeMethod( item );
        var thisFlightData = flightData[aircraftName] as Tuple<double[], double[], double[], string[]>; 
        //------------------------------------------------------
        ***// Question: how do I progressively add the values (vehicle*)
        // to each respective array such that the arrays are updated
        // (e.g., new value at bottom) with each new set of values?
        //------------------------------------------------------***
        thisFlightData.Item1[index] = // whatever
        // repeat for each array
        index++;
    }
