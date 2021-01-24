    DTE2 dte = this.ServiceProvider.GetService(typeof(DTE)) as DTE2;
                FileCodeModel fcm = dte.ActiveDocument.ProjectItem.FileCodeModel as FileCodeModel;
                foreach (CodeElement element in fcm.CodeElements)
                {
                    if (element is CodeNamespace)
                    {
                        CodeNamespace nsp = element as CodeNamespace;
    
                        foreach (CodeElement subElement in nsp.Children)
                        {
                            if (subElement is CodeClass)
                            {
                                CodeClass c2 = subElement as CodeClass;
                                foreach (CodeElement item in c2.Children)
                                {
                                    if (item is CodeFunction)
                                    {
                                        CodeFunction cf = item as CodeFunction;
                                        MessageBox.Show(cf.Name);
                                    }
                                }
                            }
                        }
                    }
                }
