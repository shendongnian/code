    public class TUnitArrayClass
    {
        [JsonConstructor]
        TUnitArrayClass(TypeWrapper<Enum>[] units)
            : this(units == null ? null : units.Select(s => s.Value()).ToArray())
        {
        }
        public TUnitArrayClass(IEnumerable<System.Enum> units)
        {
            this.Units = (units ?? Enumerable.Empty<System.Enum>()).ToArray();
        }
        [JsonIgnore]
        public System.Enum[] Units { get; set; }
        [JsonProperty("Unit", TypeNameHandling = TypeNameHandling.All)]
        TypeWrapper<Enum> [] UnitsSurrogate
        {
            get
            {
                return Units == null ? null : Units.Select(u => TypeWrapper<Enum>.CreateWrapper(u)).ToArray();
            }
            set
            {
                if (value == null)
                    Units = null;
                else
                    Units = value.Select(s => s.Value()).ToArray();
            }
        }
    }
