	public class ClassUsingReaderWriterLockSlim
	{
		private ReaderWriterLockSlim rwsLock;
		public void MethodThatAcquiresLock()
		{
			rwsLock.EnterWriteLock();
		}
		public void MethodThatReleasesLock()
		{
			rwsLock.ExitWriteLock();
		}
	}
