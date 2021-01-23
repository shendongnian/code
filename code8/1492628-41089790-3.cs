            EnvDTE.DTE dte = this.GetService(typeof(Microsoft.VisualStudio.Shell.Interop.SDTE)) as EnvDTE.DTE;
            EnvDTE80.Solution2 solution = (EnvDTE80.Solution2)dte.Solution;
            try {
                /*
                 * NOTE while the MSDN sample states you must open an existing solution for the code to work,
                 * it works also without opening a solution.
                 */
                string solutionPath = @"F:\Dev\Visual Studio 2013\Packages\Spikes\VSPNewSolution\Test\MySolution";
                solution.Create(solutionPath, "MySolution");
                string templatePath = solution.GetProjectTemplate("ConsoleApplication.zip", "CSharp");
                string projectPath = solutionPath + @"\MyProject";
                /*
                 * from MZTools site :
                 * Once you have the template file name, you can add a project to the solution using the EnvDTE80.Solution.AddFromTemplate method.
                 * Note: this method returns null (Nothing) rather than the EnvDTE.Project created, 
                 * so you may need to locate the created project in the Solution.Projects collection. 
                 * See PRB: Solution.AddXXX and ProjectItems.AddXXX methods return Nothing (null).
                 */
                EnvDTE.Project project = solution.AddFromTemplate(templatePath, projectPath, "MyProject", false); 
                
                // the following code would do since there is only a single project
                //project = solution.Projects.Item(1); 
                
                // tried this :
                // project = solution.Projects.Item("MyProject"); 
                // but it throws an invalid argument exception
                // search project by name
                foreach (EnvDTE.Project p in solution.Projects) {
                    if (p.Name == "MyProject") {
                        project = p;
                        break;
                    }
                }
                // add a reference to NUnit
                VSLangProj.VSProject vsProject = (VSLangProj.VSProject)project.Object;
                vsProject.References.Add("NUnit.Framework");
                // Retrieve the path to the class template.
                string itemPath = solution.GetProjectItemTemplate("Class.zip", "CSharp");
                //Create a new project item based on the template, in this case, a Class.
                /*
                 * Here we find the same problem as with solution.AddFromTemplate(...) ( see above )
                 */
                EnvDTE.ProjectItem projectItem = project.ProjectItems.AddFromTemplate(itemPath, "MyClass.cs");
                solution.SaveAs(solutionPath + @"\MySolution.sln");                                
                project.Save();
                
                // retrieve the new class we just created
                EnvDTE.CodeClass codeClass = ClassFinder.FindClassInProjectItems(project, "MyClass");                               
                if (codeClass != null) {
                    DisplayClassFullSource(codeClass);
                    AddUsingDirectiveToClass(codeClass, "NUnit.Framework");
		            project.Save();
                    DisplayClassFullSource(codeClass);
                }
                
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show("ERROR: " + ex.Message);
            }            
        } 
