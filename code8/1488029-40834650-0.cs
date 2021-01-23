    static T DynamicParse<T>(string s) {
        return (T) Convert.ChangeType(s, typeof(T));
    }
    string s = "123";
    int i = DynamicParse<int>(s);
    double d = DynamicParse<double>(s);
