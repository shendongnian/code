            DoThing doThing = new DoThing();
            //loop through types which are IFoo
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => typeof(IFoo).IsAssignableFrom(p) && p.IsClass))
            {
                //call DoThing.Doit<t> method using reflection
                MethodInfo method = typeof(DoThing).GetMethod("Doit");
                MethodInfo generic = method.MakeGenericMethod(type);
                generic.Invoke(doThing, null);
            }
