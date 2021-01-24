    public sealed class Symbol
    {
    	public static readonly Symbol ONE = new Symbol(new[] { OrderType.Limit, OrderType.LimitMaker, OrderType.Market, OrderType.StopLossLimit, OrderType.TakeProfitLimit });
    	public static readonly Symbol TWO = new Symbol(new[] { OrderType.Limit, OrderType.LimitMaker, OrderType.Market, OrderType.StopLossLimit, OrderType.TakeProfitLimit });
    	public static readonly Symbol THREE = new Symbol(new[] { OrderType.Limit, OrderType.LimitMaker, OrderType.Market, OrderType.StopLossLimit, OrderType.TakeProfitLimit });
    	// 264 such lines in total
    	
    	public Symbol(IEnumerable<OrderType> orderTypes)
    	{
    	
    	}
    }
