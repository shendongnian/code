    [CompilerGenerated]
    private sealed class <GetEnumerable>d__0 : IEnumerable<Animal>, IEnumerable, IEnumerator<Animal>, IEnumerator, IDisposable
    {
    	private Animal <>2__current;
    
    	private int <>1__state;
    
    	private int <>l__initialThreadId;
    
    	public FarmCollection <>4__this;
    
    	public Animal <a>5__1;
    
    	public Animal[] <>7__wrap3;
    
    	public int <>7__wrap4;
    
    	Animal IEnumerator<Animal>.Current
    	{
    		[DebuggerHidden]
    		get
    		{
    			return this.<>2__current;
    		}
    	}
    
    	object IEnumerator.Current
    	{
    		[DebuggerHidden]
    		get
    		{
    			return this.<>2__current;
    		}
    	}
    
    	[DebuggerHidden]
    	IEnumerator<Animal> IEnumerable<Animal>.GetEnumerator()
    	{
    		FarmCollection.<GetEnumerable>d__0 <GetEnumerable>d__;
    		if (Environment.CurrentManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
    		{
    			this.<>1__state = 0;
    			<GetEnumerable>d__ = this;
    		}
    		else
    		{
    			<GetEnumerable>d__ = new FarmCollection.<GetEnumerable>d__0(0);
    			<GetEnumerable>d__.<>4__this = this.<>4__this;
    		}
    		return <GetEnumerable>d__;
    	}
    
    	[DebuggerHidden]
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return this.System.Collections.Generic.IEnumerable<ConsoleApplication479.Animal>.GetEnumerator();
    	}
    
    	bool IEnumerator.MoveNext()
    	{
    		bool result;
    		try
    		{
    			switch (this.<>1__state)
    			{
    			case 0:
    				this.<>1__state = -1;
    				this.<>1__state = 1;
    				this.<>7__wrap3 = this.<>4__this._farm;
    				this.<>7__wrap4 = 0;
    				goto IL_8D;
    			case 2:
    				this.<>1__state = 1;
    				this.<>7__wrap4++;
    				goto IL_8D;
    			}
    			goto IL_A9;
    			IL_8D:
    			if (this.<>7__wrap4 < this.<>7__wrap3.Length)
    			{
    				this.<a>5__1 = this.<>7__wrap3[this.<>7__wrap4];
    				this.<>2__current = this.<a>5__1;
    				this.<>1__state = 2;
    				result = true;
    				return result;
    			}
    			this.<>m__Finally2();
    			IL_A9:
    			result = false;
    		}
    		catch
    		{
    			this.System.IDisposable.Dispose();
    			throw;
    		}
    		return result;
    	}
    
    	[DebuggerHidden]
    	void IEnumerator.Reset()
    	{
    		throw new NotSupportedException();
    	}
    
    	void IDisposable.Dispose()
    	{
    		switch (this.<>1__state)
    		{
    		case 1:
    			break;
    		case 2:
    			break;
    		default:
    			return;
    		}
    		this.<>m__Finally2();
    	}
    
    	[DebuggerHidden]
    	public <GetEnumerable>d__0(int <>1__state)
    	{
    		this.<>1__state = <>1__state;
    		this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
    	}
    
    	private void <>m__Finally2()
    	{
    		this.<>1__state = -1;
    	}
    }
