	private int TryPopCore(int count, out ConcurrentStack<T>.Node poppedHead)
	{
		SpinWait spinWait = default(SpinWait);
		int num = 1;
		Random random = new Random(Environment.TickCount & 2147483647);
		ConcurrentStack<T>.Node head;
		int num2;
		while (true)
		{
			head = this.m_head;
			if (head == null)
			{
				break;
			}
			ConcurrentStack<T>.Node node = head;
			num2 = 1;
			while (num2 < count && node.m_next != null)
			{
				node = node.m_next;
				num2++;
			}
			if (Interlocked.CompareExchange<ConcurrentStack<T>.Node>(ref this.m_head, node.m_next, head) == head)
			{
				goto Block_5;
			}
			for (int i = 0; i < num; i++)
			{
				spinWait.SpinOnce();
			}
			num = (spinWait.NextSpinWillYield ? random.Next(1, 8) : (num * 2));
		}
		if (count == 1 && CDSCollectionETWBCLProvider.Log.IsEnabled())
		{
			CDSCollectionETWBCLProvider.Log.ConcurrentStack_FastPopFailed(spinWait.Count);
		}
		poppedHead = null;
		return 0;
		Block_5:
		if (count == 1 && CDSCollectionETWBCLProvider.Log.IsEnabled())
		{
			CDSCollectionETWBCLProvider.Log.ConcurrentStack_FastPopFailed(spinWait.Count);
		}
		poppedHead = head;
		return num2;
	}
