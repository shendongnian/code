    class WatchList
    {
    	public int WatchListId;
    	public int Position;
    }
	List<WatchList> original = new List<WatchList>
	{
		new WatchList{WatchListId=1, Position=1},
		new WatchList{WatchListId=2, Position=2},
		new WatchList{WatchListId=3, Position=3},
		new WatchList{WatchListId=4, Position=4},
		new WatchList{WatchListId=5, Position=5}
	};
	List<WatchList> input = new List<WatchList>
	{
		new WatchList{WatchListId=1, Position=5},
		new WatchList{WatchListId=3, Position=1},
		new WatchList{WatchListId=5, Position=4}
	};
