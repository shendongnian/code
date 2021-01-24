using MicrosoftGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AddMigrationRunner {
	class Program {
		static void Main(string[] args) {
			var generator = (Generator) new Something.Deep.Somewhere.MyCustomGenerator(); // reverse casted simply to dictate the "angle" from which we are coming.
			// PMC:> Add-Migration MyMigrationName
			generator.AddMigration("MyMigrationName"); 
		}
	}
}
namespace MicrosoftGenerator {
    // meant to be a rough "clone" of: https://github.com/mono/entityframework/blob/master/src/EntityFramework/Migrations/Design/CSharpMigrationCodeGenerator.cs
	public class Generator {
		private List<MigrationOperation> operations = new List<MigrationOperation>() { };
		public Generator() {
			operations.Add(new AddColumnOperation());
		}
		public void AddMigration(string name) {
			Generate(name, operations);
		}
		public virtual void Generate(string migrationId, IEnumerable<MigrationOperation> operations) {
			Console.WriteLine("Up() method generating..");
			operations.Each<dynamic>(o => Generate(o));
		}
		protected void Generate(AddColumnOperation op) {
			Console.WriteLine("<AddColumnOperation> execute.");
		}
	}
	public class AddColumnOperation : MigrationOperation {}
	public class MigrationOperation {}
    
 //https://github.com/mono/entityframework/blob/master/src/Common/IEnumerableExtensions.cs
	public static class MicrosoftUtilities {
		public static void Each<T>(this IEnumerable<T> ts, Action<T> action) {
			foreach (var t in ts) {
				action(t);
			}
		}
	}
}
namespace Something.Deep.Somewhere {
	public class MyCustomGenerator : Generator {
		public MyCustomGenerator() : base() {
			
		}
		public override void Generate(string migrationId, IEnumerable<MigrationOperation> operations) {
			var extendedOperations = operations.ToList();
			extendedOperations.Add(new MyCustomOperation());
			
			base.Generate(migrationId, extendedOperations);
		}
		protected void Generate(MyCustomOperation op) {
			Console.WriteLine("<MyCustomOperation> execute.");
		}
	}
	public class MyCustomOperation : MigrationOperation {
	}
}
So by splitting up the custom .Each action executor, into a foreach, we can see that it does work fine if coded decently.
			//operations.Each<dynamic>(o => Generate(o));
			foreach(var op in operations) {
				Type op_type = op.GetType();
				var actionT = typeof (Action<>).MakeGenericType(op_type);
				var methodInfo = this.GetType().GetMethod("Generate", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { op_type }, null);
				methodInfo.Invoke(this, new object[]{ op });
			}
I'm out of my depth at this point, to explain why it is that a delegate action with a valid object and instance cannot resolve itself. 
I suppose this is a good example of why you should not use `dynamic` in a lazy fashion. *Cough* @microsoft.
I don't see any way to resolve this without modifying the EntityFramework source code.
The use of `dynamic` would be ok, if they weren't also using a runtime bound Extension method to execute the method as a hard `<type>` parameterized action; since if it was kept as `dynamic` it would remain runtime bound.
As proven (it works!) if you modify their root `Generate` method like so (as per sample above): 
		public virtual void Generate(string migrationId, IEnumerable<MigrationOperation> operations) {
			Console.WriteLine("Up() method generating..");
			operations.Each<dynamic>(o => ((dynamic)this).Generate(o));
		}
Notice the `((dynamic)this)` cast.
So 3 things:
 1. Thank you for posting this, is exactly what I need also
 2. Sorry I don't have a solution
 3. and hopefully with this Intel typed out here explicitly, someone with a great mind can show us a way to bypass this problem without opening a ticket on Microsoft's account.
So if you want to keep your code clean like we both do, the only solution I can think of is to NOT call `base.Generate()`, and instead implement a copy/paste of their source code; such that you may override their extension method `.Each` call to `delegate`. Which is obviously problematic for nuget updates and future dev's who know-not what they do.
