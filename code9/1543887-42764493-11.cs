        [TestMethod]
        public void MicroTest2()
        {
            var action = InitWithNull<ExtUser, int?>(x => x.NIntId, "MicroTest2Impl");
            
            ExtUser u = new ExtUser();
            u.NIntId = 1;
            action( u);
          
            Assert.IsNull(u.NIntId);
        }
        private static Action<TObject> InitWithNull<TObject, TProperty>(
            Expression<Func<TObject,TProperty>> property, string name)
        {
            
            var method = new DynamicMethod(name, null,
                new Type[] { typeof(TObject) });
            var il = method.GetILGenerator();
            var prop = LinqExt.GetPropertyFast(property);
            //we start with an empty stack here
            
            var local = il.DeclareLocal(typeof(TProperty));
            il.Emit(OpCodes.Ldarg_0); //push data
            il.Emit(OpCodes.Ldloca, local);
            il.Emit(OpCodes.Initobj, typeof(TProperty));
            
            il.Emit(OpCodes.Ldloc, local.LocalIndex);
            //stack is now data, new TProperty?()
            il.EmitCall(OpCodes.Callvirt, prop.GetSetMethod(), null);
            //stack empty
            il.Emit(OpCodes.Ret);
            var action = (Action<TObject>)method.CreateDelegate(typeof(Action<TObject>));
            return action;
        }
