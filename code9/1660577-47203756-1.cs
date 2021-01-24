    for (int i = 0; i < GameManager.Instance.AvailableUpgrades.Count; i++) {
        // Do you thing
        if (/*some possible condition*/) {
            GameManager.Instance.DisplayedUpgrades.Add(/*some new Object*/);
        }
        if (/*another possible condition*/) {
            GameManager.Instance.AvailableUpgrades.RemoveAt(i);
            i--; // Since i is pointing to current object that was just removed
            // Otherwise you'd skip one object
        }
    }
