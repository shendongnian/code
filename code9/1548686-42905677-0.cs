	public static IObservable<T> SampleSometimes<T>(this IObservable<T> source, TimeSpan sampleTime, IObservable<bool> isSamplingOn)
	{
		return source.Publish(_source => _source
			.Sample(sampleTime)
			.Publish( _sampled => isSamplingOn
				.Select(b => b? _sampled : _source)
				.Switch()
			)
		);
	}
