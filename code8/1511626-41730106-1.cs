    // this would be how to call...
    foreach (var item in ReadFile<RAMPrec2>("testFile.bin", 0).Select((v, i) => new { Value = v, Index = i }))
    {
        var vehicle = vehicles[item.Index];
        var ramp = item.Value;
        vehicle.NowTime.Add(ramp.now);
        vehicle.VehLat.Add(ramp.VehLatitude / MILLIARCTODEG);
        vehicle.VehLong.Add(ramp.VehLongitude / MILLIARCTODEG);
        vehicle.VehHead.Add(ramp.VehHeading);
        vehicle.VehSpeed.Add(ramp.VehSpeed);
        vehicle.VehTWD.Add(ramp.VehAltitude + ramp.VehDepth);
        vehicle.VehAlt.Add(ramp.VehAltitude);
        vehicle.VehDep.Add(ramp.VehDepth);
        vehicle.VehRoll.Add(ramp.VehRoll);
        vehicle.VehPit.Add(ramp.VehPitch);
    }
