			    Assembly asm = typeof(ICustomeAttribute).GetTypeInfo().Assembly; //thanks to @mjwills  for his helpfull comment
				
				var types = asm.DefinedTypes.Where(x=>x.ImplementedInterfaces.Contains(typeof(ICustomeAttribute)));
				foreach (var type in types)
				{
                    //do stuff
					Console.WriteLine("class name: {0} - {1}",type.Name,type.FullName);
				}
