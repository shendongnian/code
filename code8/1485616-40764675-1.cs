    public class SpecificBuilder : IBuilder<Int32> {
        // The specific constructor
    	public SpecificBuilder(int param) { BuildParameter = param; }
        // Implement from IBuilder
		public void Build() {
			System.Console.WriteLine("Building with Int32: " + BuildParameter);
		}
        // Implement from IBuilder<T>
		public Int32 BuildParameter {get; private set;}
	}
