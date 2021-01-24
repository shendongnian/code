    Dictionary<Keys, int> _mods = new Dictionary<Keys, int> {
        { Keys.Alt, 1 },
        { Keys.Control, 2 },
        { Keys.Alt ^ Keys.Control, 3 },
        { Keys.Shift, 4 },
        { Keys.Alt ^ Keys.Shift, 5 },
        { Keys.Shift ^ Keys.Control, 6 },
        { Keys.Alt ^ Keys.Shift ^ Keys.Control, 7}
    };
