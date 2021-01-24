            foreach (var c in correctRoot.DescendantNodesAndSelf())
            {
                var classDeclaration = c as ClassDeclarationSyntax;
                if (classDeclaration == null)
                {
                    continue;
                }
                if (classDeclaration.BaseList?.Types.Count > 0)
                {
                    Console.WriteLine("This class has base class or it implements interfaces");
                }
                else
                {
                    /*Add inherition*/
                }
            }
