        public void MiniTest()
        {
            IDbConnection con = Session.Connection;
            var method = new DynamicMethod("test", null,
                new Type[] { typeof(IDataReader), typeof(MyOrder) });
            var il = method.GetILGenerator();
            var defaultLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            // generate isdbnull check
            il.Emit(OpCodes.Ldarg_0); //push reader
            il.Emit(OpCodes.Ldc_I4, 0); //push idx on stack
            il.EmitCall(OpCodes.Callvirt, typeof(IDataRecord).GetMethod("IsDBNull"), null);
            il.Emit(OpCodes.Brtrue_S, defaultLabel);
            //stack now empty
            //do the read call and assign the value
            il.Emit(OpCodes.Ldarg_1); //push data
            il.Emit(OpCodes.Ldarg_0); //push reader
            il.Emit(OpCodes.Ldc_I4, 0); //push idx on stack
            il.EmitCall(OpCodes.Callvirt, typeof(IDataRecord).GetMethod("GetDateTime"), null); // call r.Get...(idx) and push result on stack
            //stack is data, DateTime
            var ctor = typeof(DateTime?).GetConstructor(new[] { typeof(DateTime) });
            il.Emit(OpCodes.Newobj, ctor); // create the system.nullable and push it on stack
            // stack is data, DateTime?
            var prop = LinqExt.GetPropertyFast<MyOrder, DateTime?>(x => x.Shipment);
            il.EmitCall(OpCodes.Callvirt, prop.GetSetMethod(), null); // call d.Property setter
            //consumes data + Datetime? value
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(defaultLabel);
            //we start with an empty stack here
            il.Emit(OpCodes.Ldarg_1); //push data
            var local = il.DeclareLocal(typeof(DateTime?));
            il.Emit(OpCodes.Ldloca, local);
            il.Emit(OpCodes.Initobj, typeof(DateTime?));
            il.Emit(OpCodes.Ldloc, local.LocalIndex);
            //stack is now data, new DateTime?()
            il.EmitCall(OpCodes.Callvirt, prop.GetSetMethod(), null);
            //stack empty
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);
            var action = (Action<IDataReader, MyOrder>)method.CreateDelegate(typeof(Action<IDataReader, MyOrder>));
            List<MyOrder> data = new List<MyOrder>();
            using (var reader = con.Query(
    @"Select o.Shipment
     from TestOrder o
     where o.Order_Id = :id",
                0,
                new { id = 1 }))
            {
                while(reader.Read())
                {
                    MyOrder u = new MyOrder();
                    action(reader, u);
                    data.Add(u);
                }
            }
                
            Assert.AreEqual(1, data.Count);
            Assert.IsNull( data[0].Shipment);
        }
