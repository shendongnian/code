    enum State
    {
        SpaceEncountered,
        ArticleEncountered,
        Default
    };
    static int CountArticles(string text)
    {
        int count = 0;
        State state = State.SpaceEncountered; // start of line behaves the same
        for (int i = 0; i < text.Length; ++i)
        {
            switch (state)
            {
                case State.SpaceEncountered:
                    if (text[i] == 'a' || text[i] == 'A')
                    {
                        state = State.ArticleEncountered;
                    }
                    else if (!char.IsWhiteSpace(text[i]))
                    {
                        state = State.Default;
                    }
                    break;
                case State.ArticleEncountered:
                    if (char.IsWhiteSpace(text[i]))
                    {
                        ++count;
                        state = State.SpaceEncountered;
                    }
                    else
                    {
                        state = State.Default;
                    }
                    break;
                case State.Default: // state 2 = 
                    if (char.IsWhiteSpace(text[i]))
                    {
                        state = State.SpaceEncountered;
                    }
                    break;
            }
        }
        // if we're in state ArticleEncountered, the next is EOF and we should count one extra
        if (state == State.ArticleEncountered)
        {
            ++count;
        }
        return count;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(CountArticles("A book was lost. There is a book on the table. Is that the book?"));
        Console.ReadLine();
    }
