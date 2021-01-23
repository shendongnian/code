    //top of file
    using State = System.Tuple<System.Text.StringBuilder, bool>;
	string Format (string str, char separator)
	{
		var initialState = Tuple.Create (new StringBuilder (str.Length), false);
		Func<State, StringBuilder> addSeparatorIfPrevDiscarded = state => state.Item2 ? state.Item1.Append (separator) : state.Item1;
		Func<State, char, State> aggregator = (state, ch) => char.IsLetterOrDigit (ch) ? Tuple.Create (addSeparatorIfPrevDiscarded (state).Append (ch), false) : Tuple.Create (state.Item1, true);
		Func<State, string> resultSelector = state => addSeparatorIfPrevDiscarded (state).ToString ();
		
		return str.Aggregate (initialState, aggregator, resultSelector);
	}
