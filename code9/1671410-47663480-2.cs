	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace StackOverflow
	{
		public class App_Conversion
		{
			public void Run()
			{
				var weight = getWeightUnitGroup();
				var w = weight.Convert("g", "kg");
				Console.WriteLine(w.ToString());
				var x = weight.Convert(400, "kg", "g");
				Console.WriteLine(x.ToString());
				var y = weight.Convert(12, "lb", "g");
				Console.WriteLine(y.ToString());
				var z = weight.Convert(7, "g", "lb");
				Console.WriteLine(z.ToString());
			}   
			private UnitGroup getWeightUnitGroup() 
			// we could also get the data from wherever and deserialize into these classes       
			{
				//base unit for the weight Unit Group
				var gram = new Unit("g", 1);
				var weight = new UnitGroup("Weight", UnitGroup.eType.Mass, gram);
				weight.AddUnit(new Unit("kg", 1000m));
				weight.AddUnit(new Unit("mg", 0.001m));
				weight.AddUnit(new Unit("oz", 28.35m));
				weight.AddUnit(new Unit("lb", 453.59m));
				return weight;
			}
		}
		public class UnitGroup
		{
			public enum eType
			{
				Mass = 1,
				Distance = 2
			}
			public eType Type { get; private set; }
			public string Name { get; private set; }
			public Unit BaseUnit { get; private set; }
			public List<Unit> Units { get; private set; } = new List<Unit>();
			public UnitGroup(string name, eType type, Unit baseUnit)
			{
				Name = name;
				Type = type;
				BaseUnit = baseUnit;
				AddUnit(baseUnit);
			}
			public void AddUnit(Unit unit)
			{
				Units.Add(unit);
				unit.AddToGroup(this);
			}
			public ConversionResult Convert(string fromName, string toName)
			{
				return Convert(1, fromName, toName);
			}
			public ConversionResult Convert(decimal qty, string fromName, string toName)
			{
				var from = Units.Where(u => u.Name.Equals(fromName)).First();
				var to = Units.Where(u => u.Name.Equals(toName)).First();
				var result = Decimal.Round(qty * (from.Quantity * to.ConvertToFactor),5);
				var formattedResult = $"{qty} {fromName} = {result} {toName}";
				return new ConversionResult(result, formattedResult);
			}
		}
		public class Unit
		{        
			public UnitGroup Group { get; private set; }
			public string Name { get; private set; }        
			public decimal Quantity { get; private set; }
			public decimal ConvertToFactor
			{
				get
				{
					return Group.BaseUnit.Quantity / Quantity;
				}
			}
			public Unit(string name, decimal qty)
			{
				Name = name;
				Quantity = qty;
			}
			public void AddToGroup(UnitGroup group)
			{
				Group = group;
			}
		}
		public class ConversionResult
		{
			private string formattedResult;
			public decimal Result { get; private set; }
			
			public ConversionResult(decimal result, string formattedResult)
			{
				Result = result;
				this.formattedResult = formattedResult;
			}
			public override string ToString()
			{
				return formattedResult;
			}
		}
	}
