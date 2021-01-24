    public List<string> readWordsFromFile(string file) {
        list<string> result = new List<string>();
        using(Streamreader sr = new Streamreader(file)) {
            while(!sr.EndOfFile) { // making sure to read the whole file
                result.Append(sr.ReadLine().Split(" ")); // splitting words by " " (space)
            }
        }
        return result;
    }
