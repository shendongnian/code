    private static IEnumerable<string> EnumerateLetters(int length) {
        for (int i = 1; i <= length; i++) {
            foreach (var letters in EnumerateLettersExact(i)) {                  
                yield return letters;
            }
        }
    }
    private static IEnumerable<string> EnumerateLettersExact(int length) {
        if (length == 0) {
            yield return "";
        }
        else {
            for (char c = 'A'; c <= 'Z'; ++c) {
                foreach (var letters in EnumerateLettersExact(length - 1)) {
                    yield return c + letters;
                }
            }    
        }
    }
    private static void Main(string[] args) {
        foreach (var letters in EnumerateLetters(2)) {
            Console.Write($"{letters} ");
        }
    }
