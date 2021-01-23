      List<Mastery> maxList = new List<Mastery>();
                var max = 0;
    
                foreach (var list in MasteryList)
                {
                    var masteryList = list
                        .GroupBy(gp => new { gp.ID, gp.Rank })  // Agrupamos por ID y Rango
                        .OrderByDescending(g => g.Count())      // Ordenamos de mayor a menor
                        .Select(x => new { Key = x.Key, Count = x.Count() })    // Seleccionamos el valor y la cantidad de repeticiones
                        .ToList();
    
                    var maxCurrent = masteryList.Max(x => x.Count);
    
                    if (max < maxCurrent)
                    {
                        maxList = list;
                        max = maxCurrent;
                    }
                }
