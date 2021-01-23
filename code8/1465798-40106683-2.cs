    namespace _01_simple {
	using System;
	using LiteDB;
	public class A {
		public int Id { set; get; }
		public string Name { set; get; }
		public B B_Ref { set; get; }
	}
	public class B {
		public int Id { set; get; }
		public string Name { set; get; }
		public C C_Ref { set; get; }
	}
	public class C {
		public int Id { set; get; }
		public string Name { set; get; }
		public D D_Ref { set; get; }
	}
	public class D {
		public int Id { set; get; }
		public string Name { set; get; }
	}
	class Program {
		static void Main(string[] args) {
			test_01();
		}
		static string NameInDb<T>() {
			var name = typeof(T).Name + "s";
			return name;
		}
		static void test_01() {
			if (System.IO.File.Exists(@"MyData.db"))
				System.IO.File.Delete(@"MyData.db");
			using (var db = new LiteDatabase(@"MyData.db")) {
				var As = db.GetCollection<A>(NameInDb<A>());
				var Bs = db.GetCollection<B>(NameInDb<B>());
				var Cs = db.GetCollection<C>(NameInDb<C>());
				var Ds = db.GetCollection<D>(NameInDb<D>());
				LiteDB.BsonMapper.Global.Entity<A>().DbRef(x => x.B_Ref, NameInDb<B>());
				LiteDB.BsonMapper.Global.Entity<B>().DbRef(x => x.C_Ref, NameInDb<C>());
				LiteDB.BsonMapper.Global.Entity<C>().DbRef(x => x.D_Ref, NameInDb<D>());
				var d = new D { Name = "I am D." };
				var c = new C { Name = "I am C.", D_Ref = d };
				var b = new B { Name = "I am B.", C_Ref = c };
				var a = new A { Name = "I am A.", B_Ref = b };
				Ds.Insert(d);
				Cs.Insert(c);
				Bs.Insert(b);
				As.Insert(a);
			}
			using (var db = new LiteDatabase(@"MyData.db")) {
				var As = db.GetCollection<A>(NameInDb<A>());
				var all_a = As
					.Include(x => x.B_Ref)
					.Include(x => x.B_Ref.C_Ref)
					.Include(x => x.B_Ref.C_Ref.D_Ref)
					.FindAll();
				foreach (var a in all_a) {
					if (a.B_Ref == null)
						throw new Exception("B_Ref");
					if (a.B_Ref.C_Ref == null)
						throw new Exception("C_Ref");
					if (a.B_Ref.C_Ref.D_Ref == null)
						throw new Exception("D_Ref");
				}
			}
		}
	}}
