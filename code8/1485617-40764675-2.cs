	public class Program {
		public static void Main() {
			SpecificBuilder builder = new SpecificBuilder(42);
            // SpecificBuilder implements IBuilder<Int32>
            // Build accepts any IBuilder
            // So this is legal:
			Build(builder);
		}
        //
        // Note this method accepts anything that inherits from IBuilder
        // 
		public static void Build(IBuilder builder) {
			builder.Build();
            // If you'd need access to the BuildParameter of IBuilder<T>
            // then this pattern fails you here.
            // Unless of course you want to check for types and cast
		}
	}
