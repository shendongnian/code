	public abstract class Channel
	{
		// inner class is a property of outer class
        public Sensor Sensor { get; set; }
        // Public method in outer class calls internal method in inner class
		public void AddSamples(IEnumerable<double> samples)
		{
			Sensor?.AddSamplesInternal(samples);
		}
	}
	public abstract class Sensor
	{
        // domain specific property exposing the effects of template method
		public abstract IObservable<double> WhenNewSamples { get; }
        // internal method forwards the call to a protected abstract "template" method
		internal void AddSamplesInternal(IEnumerable<double> samples)
		{
			AddSamplesProtected(samples);
		}
        // protected abstract method to be implemented by subclasses
		protected abstract void AddSamplesProtected(IEnumerable<double> samples);
	}
