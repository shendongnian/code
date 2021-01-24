    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DbC>());
            // initialize some test data
            using (var db = new DbC())
            {
                var t1_1 = db.Type1Objects.Add(new ObjectType1Model { Data = "Object T1 1" });
                var t1_2 = db.Type1Objects.Add(new ObjectType1Model { Data = "Object T1 2" });
                var t2_1 = db.Type2Objects.Add(new ObjectType2Model { Data = "Object T2 1" });
                var t2_2 = db.Type2Objects.Add(new ObjectType2Model { Data = "Object T2 2" });
                db.SaveChanges();
                db.Objects.Add(new ObjectModel { ObjectTypeID = t1_1.ID, ObjectTypeDiscriminator = "Type1" });
                db.Objects.Add(new ObjectModel { ObjectTypeID = t1_2.ID, ObjectTypeDiscriminator = "Type1" });
                db.Objects.Add(new ObjectModel { ObjectTypeID = t2_1.ID, ObjectTypeDiscriminator = "Type2" });
                db.Objects.Add(new ObjectModel { ObjectTypeID = t2_2.ID, ObjectTypeDiscriminator = "Type2" });
                db.SaveChanges();
            }
            // fresh context for query demonstration
            using (var db = new DbC())
            {
                db.Database.Log = x => Console.WriteLine(x);
                var result =
                    from o in db.Objects
                    join t1 in db.Type1Objects on new { Discriminator = o.ObjectTypeDiscriminator, ObjectTypeID = o.ObjectTypeID } equals new { Discriminator = "Type1", ObjectTypeID = t1.ID } into types1
                    join t2 in db.Type2Objects on new { Discriminator = o.ObjectTypeDiscriminator, ObjectTypeID = o.ObjectTypeID } equals new { Discriminator = "Type2", ObjectTypeID = t2.ID } into types2
                    from t1 in types1.DefaultIfEmpty()
                    from t2 in types2.DefaultIfEmpty()
                    select new
                    {
                        Obj = o,
                        T1 = t1,
                        T2 = t2,
                    };
                foreach (var item in result)
                {
                    // only one concrete type will have a non-null value
                    var T = (IObjectTypeModel)item.T1 ?? item.T2;
                    Console.WriteLine("{0,20}{1,20}", item.Obj.ObjectTypeDiscriminator, T.Data);
                }
            }
            Console.ReadKey();
        }
    }
