    retry:
	try {
	   // Create a new Transaction object for this partition
	   using (ITransaction tx = base.StateManager.CreateTransaction()) {
	      // AddAsync takes key's write lock; if >4 secs, TimeoutException
	      await m_dic.AddAsync(tx, key, value, cancellationToken);
	      await tx.CommitAsync();
	   }
	}
	catch (TimeoutException) {
	   await Task.Delay(100, cancellationToken); goto retry;
	}
