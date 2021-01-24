	internal class PathFindingThread
		{
			Task m_Worker;
			ConcurrentQueue<CompletedProcessingCallback> m_CallbackQueue;
			ConcurrentQueue<IAlgorithm> m_QueuedTasks;
			internal int GetTaskCount
			{
				get
				{
					return m_QueuedTasks.Count;
				}
			}
			internal PathFindingThread()
			{
				m_CallbackQueue = new ConcurrentQueue<CompletedProcessingCallback>();
				m_QueuedTasks = new ConcurrentQueue<IAlgorithm>();
				m_Worker = Task.Factory.StartNew(() =>
				{
					while (true)
					{
						IAlgorithm head = null;
						if (m_QueuedTasks.TryDequeue(out head))
						{
							head.FindPath(new IAlgorithmCompleted(AddCallback));
						}
						else
						{
							Task.Delay(0);
						}
					}
				});
			}
			internal void AddJob(IAlgorithm AlgorithmToRun)
			{
				m_QueuedTasks.Enqueue(AlgorithmToRun);
			}
			private void AddCallback(CompletedProcessingCallback callback)
			{
				m_CallbackQueue.Enqueue(callback);
			}
			private void Update()
			{
				CompletedProcessingCallback cb = null;
				if (m_CallbackQueue.TryDequeue(out cb))
				{
					cb.m_Callback.Invoke(cb.m_Path);
				}
			}
		}
