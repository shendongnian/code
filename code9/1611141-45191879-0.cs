    public static void RemoveDuplicates(Service service) {
        var toRemove = new HashSet<string>();
        RemoveDuplicates(service, toRemove);
    }
    private static void RemoveDuplicates(Service service, ISet<string> toRemove) {
        // Collect all child codes, and clean up children in the process
        foreach (var child in services) {
            RemoveDuplicates(child, toRemove);
        }
        // Remove all child codes from self
        foreach (var code in toRemove) {
            service.RemoveCode(code);
        }
        // Add the remaining codes for my parents to remove
        foreach (var myCode in allMyCodes) {
            toRemove.Add(myCode);
        }
    }
