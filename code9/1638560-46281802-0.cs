        public static List<MachinePart> getFreeMovementParts(Dictionary<int, MachinePart> iMachineParts)
        {
            return Enumerable.Range(0, 99)
                .Select(i => { iMachineParts.TryGetValue(i, out var mp); return mp; })
                .Where(mp => mp != null)
                .ToList();
        }
