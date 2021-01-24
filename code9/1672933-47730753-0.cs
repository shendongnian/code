	public class PortugueseCulture : CultureInfo
    {
        private readonly Calendar cal;
        private readonly Calendar[] optionals;
        
        public PortugueseCulture()
            : this("pt-BR", true)
        {
        }
		
		public PortugueseCulture(string cultureName, bool useUserOverride) : base(cultureName, useUserOverride)
        {
			//Your Custom Currency Numbers Calendar Culture Code
		}
		
		public override Calendar Calendar
        {
            get { return cal; }
        }
        public override Calendar[] OptionalCalendars
        {
            get { return optionals; }
        }
	}
