        private void AddUsingDirectiveToClass(CodeClass codeClass, string directive) {
            CodeElement lastUsingDirective = null;
            foreach (CodeElement ce in codeClass.ProjectItem.FileCodeModel.CodeElements) {
                if (ce.Kind == vsCMElement.vsCMElementImportStmt) {
                    // save it
                    lastUsingDirective = ce;
                }
                else {
                    if (lastUsingDirective != null) {
                        // insert given directive after the last one, on a new line
                        EditPoint insertPoint = lastUsingDirective.GetEndPoint().CreateEditPoint();
                        insertPoint.Insert("\r\nusing " + directive + ";");
                    }
                }
            }
        }  
