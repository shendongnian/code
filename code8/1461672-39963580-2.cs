    var livingPopulace = _worldPopulation.Where(p => !p.IsDead());
    foreach(var pop in livingPopulace)
    {
        pop.InvokeSkills(this)
    }
    var newPopulationCount = _worldPopulation.Count(p => !p.IsDead());
