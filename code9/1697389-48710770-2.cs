    var steps = ...;
    var stepById = steps.ToDictionary(step => step.Id);
    var stepsInOrder = new List<int>();
    var visited = new HashSet<int>();
    // Make sure that when we hit 0, we'll definitely stop.
    Debug.Assert(!stepsInOrder.ContainsKey(0));
    int currentStepId = 1;
    while (stepById.TryGetValue(currentStepId, out int nextStepId))
    {
      stepsInOrder.Add(currentStepId);
      if (!visited.Add(nextStepId))
        throw new Exception($"Cycle found at step {nextStepId}");
      currentStepId = nextStepId;
    }
