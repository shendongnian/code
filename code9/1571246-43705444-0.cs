    //dot net compiler
    using System; 
    using System.CodeDom.Compiler; 
    using System.IO; 
         
    namespace IndiLogix.dotCompiler 
    { 
        class dotCompiler 
        { 
            FileInfo sourceFile;// = new FileInfo(sourceName); 
            CodeDomProvider provider = null; 
            bool compileOk = false; 
         
        
            // Compile Executable 
            public bool CompileExecutable(String sourceName) 
            { 
                sourceFile = new FileInfo(sourceName); 
                I_GetProvider(sourceFile); 
                if (sourceFile.Extension.ToUpper(System.Globalization.CultureInfo.InvariantCulture) == ".CS") 
                { 
                    provider = CodeDomProvider.CreateProvider("CSharp"); 
                    //return "CSharp"; 
                } 
         
                if (provider != null) 
                { 
         
                    // Format the executable file name. 
                    // Build the output assembly path using the current directory 
                    // and _cs.exe or _vb.exe. 
         
                    String exeName = String.Format(@"{0}\{1}.exe", 
                    System.Environment.CurrentDirectory, 
                    sourceFile.Name.Replace(".", "_")); 
                    string dllName = String.Format(@"{0}\{1}.dll", System.Environment.CurrentDirectory, sourceFile.Name.Replace(".", "_")); 
         
                    CompilerParameters cp = new CompilerParameters(); 
         
                    // Generate an executable instead of a class library. 
                    cp.GenerateExecutable = true; 
         
                    // Specify the assembly file name to generate. 
                    cp.OutputAssembly = exeName; 
         
                    // Save the assembly as a physical file. 
                    cp.GenerateInMemory = false; 
         
                    // Set whether to treat all warnings as errors. 
                    cp.TreatWarningsAsErrors = false; 
         
                    // Invoke compilation of the source file. 
                    CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceName); 
                    string temp; 
                    if (cr.Errors.Count > 0) 
                    { 
                        // Display compilation errors. 
                        temp = sourceName + "\n" + cr.PathToAssembly; 
         
                        foreach (CompilerError ce in cr.Errors) 
                        { 
                            temp += "\nError:" + ce.ToString(); 
                        } 
                        System.Windows.Forms.MessageBox.Show(temp, "dotCompiler Error:", System.Windows.Forms.MessageBoxButtons.OK); 
                    } 
                    else 
                    { 
                        // Display a successful compilation message. 
                        //Console.WriteLine("Source {0} built into {1} successfully.",sourceName, cr.PathToAssembly); 
                        System.Windows.Forms.MessageBox.Show("Solution build sucessfully..\n\n" + sourceName + "\n" + cr.PathToAssembly,"dotCompiler:)",System.Windows.Forms.MessageBoxButtons.OK); 
                    } 
         
                    // Return the results of the compilation. 
                    if (cr.Errors.Count > 0) 
                    { 
                        compileOk = false; 
                    } 
                    else 
                    { 
                        compileOk = true; 
                    } 
                } 
                return compileOk; 
            } 
         
            private void I_GetProvider(FileInfo sourceFile) 
            { 
                // Select the code provider based on the input file extension. 
                if (sourceFile.Extension.ToUpper(System.Globalization.CultureInfo.InvariantCulture) == ".CS") 
                { 
                    provider = CodeDomProvider.CreateProvider("CSharp"); 
                } 
                else if (sourceFile.Extension.ToUpper(System.Globalization.CultureInfo.InvariantCulture) == ".VB") 
                { 
                    provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("VisualBasic"); 
                } 
                else 
                { 
                    //Console.WriteLine("Source file must have a .cs or .vb extension"); 
                    //_Notify("Error:", "Source file must have a .cs or .vb extension", ToolTipIcon.Error); 
                    System.Windows.Forms.MessageBox.Show( 
                    "Source file must have *.cs or *.vb extension", "dotCompiler Error", 
                    System.Windows.Forms.MessageBoxButtons.OK); 
                } 
            } 
         
            private string I_GetProvider_RetStr(FileInfo sourceFile) 
            { 
         
                // Select the code provider based on the input file extension. 
                if (sourceFile.Extension.ToUpper(System.Globalization.CultureInfo.InvariantCulture) == ".CS") 
                { 
                    provider = CodeDomProvider.CreateProvider("CSharp"); 
                    return "CSharp"; 
                } 
                else if (sourceFile.Extension.ToUpper(System.Globalization.CultureInfo.InvariantCulture) == ".VB") 
                { 
                    provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("VisualBasic"); 
                    return "VisualBasic"; 
                } 
                else 
                { 
                    //Console.WriteLine("Source file must have a .cs or .vb extension"); 
                    //_Notify("Error:", "Source file must have a .cs or .vb extension", ToolTipIcon.Error); 
                    return "Source file must have *.cs or *.vb extension"; 
                } 
            } 
         
            public bool CompileDll(String sourceName) 
            { 
         
                sourceFile = new FileInfo(sourceName); 
                I_GetProvider(sourceFile); 
         
                if (provider != null) 
                { 
         
                // Format the executable file name. 
                // Build the output assembly path using the current directory 
                // and _cs.exe or _vb.exe. 
         
                String exeName = String.Format(@"{0}\{1}.exe", 
                System.Environment.CurrentDirectory, 
                sourceFile.Name.Replace(".", "_")); 
                string dllName = String.Format(@"{0}\{1}.dll", System.Environment.CurrentDirectory, sourceFile.Name.Replace(".", "_")); 
         
                CompilerParameters cp = new CompilerParameters(); 
         
                // Generate an executable instead of a class library. 
                cp.GenerateExecutable = false; 
         
                // Specify the assembly file name to generate. 
                cp.OutputAssembly = dllName; 
         
                // Save the assembly as a physical file. 
                cp.GenerateInMemory = false; 
         
                // Set whether to treat all warnings as errors. 
                cp.TreatWarningsAsErrors = false; 
         
                // Invoke compilation of the source file. 
                CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceName); 
                string temp; 
                if (cr.Errors.Count > 0) 
                { 
                // Display compilation errors. 
                temp = "compiling " + sourceName + " to " + cr.PathToAssembly; 
         
                foreach (CompilerError ce in cr.Errors) 
                { 
                temp += "\nError:" + ce.ToString(); 
                } 
         
                    System.Windows.Forms.MessageBox.Show(temp, "dotCompiler Error:", System.Windows.Forms.MessageBoxButtons.OK); 
                } 
                else 
                { 
                    // Display a successful compilation message. 
                    //Console.WriteLine("Source {0} built into {1} successfully.",sourceName, cr.PathToAssembly); 
                    System.Windows.Forms.MessageBox.Show("Solution build sucessfully..\n\n" + sourceName + "\n" + cr.PathToAssembly, "dotCompiler:)", System.Windows.Forms.MessageBoxButtons.OK); 
                } 
         
                    // Return the results of the compilation. 
                    if (cr.Errors.Count > 0) 
                    { 
                        compileOk = false; 
                    } 
                    else 
                    { 
                        compileOk = true; 
                    } 
                } 
            return compileOk; 
            } 
         
        } 
    } 
