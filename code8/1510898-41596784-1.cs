    using System.Linq;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
	public class ConcreteChannel : Channel
	{
        // no need to do anything - public method defined in base class
	}
	public class ConcreteSensor : Sensor
	{
        // domain specific implementation
		public override IObservable<double> WhenNewSamples
		{
			get { return _subject.AsObservable(); }
		}
		Subject<double> _subject = new Subject<double>();
        // template method implemented locally, but called from business logic present in core lib
		protected override void AddSamplesProtected(IEnumerable<double> samples)
		{
			samples.ToList().ForEach(sample => _subject.OnNext(sample));
		}
	}
