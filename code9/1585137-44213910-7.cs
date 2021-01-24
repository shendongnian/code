    protected Interval parse(String line) {
        String[] parts = line.Split(new string[] {"-"});
        int left, right;
        if (!Int32.TryParse(parts[0], left)) {
            return null; //Invalid interval
        }
        return ((parts.length <= 1) || (!Int32.TryParse(parts[1], right))) ? (new Interval(left)) : (new Interval(left, right));
    }
