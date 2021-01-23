    double liftForce(object)
    {
        const double waterLevel = 0.0;
        const double density = 1000.0; // kg/m^3 -- using water atm
        double vol = volumeBeneathSurface(object, waterLevel);
        double displacedMass = vol*density; // density = m/vol
        double displacedWeight = displacedMass*gravity; // F = m*a
        return displacedWeight;
    }
