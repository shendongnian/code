            foreach (System.Reflection.AssemblyName data in names)
            {
                var assembly = System.Reflection.Assembly.ReflectionOnlyLoad(data.FullName);
                listBox2.Items.Add(System.IO.Path.GetFileName(assembly.Location));
            }
