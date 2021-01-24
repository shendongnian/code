    private bool AreAnyInteractablesInThisList<T>(IEnumerable<T> Interactables, T InteractableToCheck) where T : IInteractable
    {
        // I cache this ID (assuming it was not changing with each call)
        int idToCheck = InteractableToCheck.GetInstanceID();
        return Interactables.Any(interactable => interactable.GetInstanceID() == idToCheck);
    }
