    public static string ToString(object obj) {
        var list = obj as IList;
        if (list != null) {
            foreach (dynamic o in list) {
                Process(o);
            }
        }
    }
    static void Process(int n) { ... }
    static void Process(string s) { ... }
    static void Process(object o) { ... }
