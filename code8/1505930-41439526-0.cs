     Type type = typeBuilder.CreateType();
            var obj1 = Activator.CreateInstance(type, new object[] { null });
            var obj2 = Activator.CreateInstance(type, obj1);
            assemblyBuilder.Save(assemblyFileName);
            var children = (IList)obj2.GetType().GetProperty(selfRefDerivedCollectionName).GetValue(obj2, null);
            ((INotifyCollectionChanged)children).CollectionChanged += Program_CollectionChanged;
            var obj3 = Activator.CreateInstance(type, new object[] { null });
            children.Add(obj3);
            var genericType = typeOfCts.MakeGenericType(type);
           
            var list = Activator.CreateInstance(genericType, new object[] { null});
            obj1 = Activator.CreateInstance(type, new object[] { null });
            list.GetType().GetMethod("Add").Invoke(list, new object[] { obj1 });
        
            obj1 = Activator.CreateInstance(type, new object[] { null });
            list.GetType().GetMethod("Add").Invoke(list, new object[] { obj1 });
            var obj4 = Activator.CreateInstance(type, new object[] { null, list });
