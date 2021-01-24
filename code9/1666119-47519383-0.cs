		public void Play(double speed)
		{
			_speed = speed;
			_cancelPlay?.Cancel();
			_cancelPlay = new CancellationTokenSource();
			Task.Run(() => PlayLoop(_cancelPlay.Token), _cancelPlay.Token);
		}
		void PlayLoop(CancellationToken token)
		{
			var sw = Stopwatch.StartNew();
			double previous = sw.ElapsedMilliseconds;
			double timeInterval = 1000.0 / (Math.Abs(_speed) * _exame.Model.Configurações.FrameRate);
			while (!token.IsCancellationRequested)
			{
				var current = sw.ElapsedMilliseconds;
				var elapsed = current - previous;
				if (elapsed > timeInterval)
				{
					Índice = Math.Max(0, Math.Min(ÍndiceMáximo, Índice + 1 * Math.Sign(_speed)));
					previous = current;
				}
			}
		}
