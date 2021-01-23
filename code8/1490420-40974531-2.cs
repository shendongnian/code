            // Init the property
            TreeViewNodes = new ObservableCollection<SyntaxTreeNode>();
            // Open the solution from the supplied path
            string solutionPath = @"Path to your solution";
            MSBuildWorkspace msWorkspace = MSBuildWorkspace.Create();
            Solution solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;
            // Analyze each project.
            foreach (var project in solution.Projects)
            {
                // Set project node
                SyntaxTreeNode projectNode = new SyntaxTreeNode();
                projectNode.Name = project.Name;
                projectNode.Type = "Project";
                projectNode.SyntaxTreeNodes = new ObservableCollection<SyntaxTreeNode>();
                // Add the defined node to the collection (first tree level).
                TreeViewNodes.Add(projectNode);
                // Set the recently added node as a “parentNode”. This will be used later to add the prebuild subnode (or a list of subnodes).
                SyntaxTreeNode parentProjectNode = CommonDataAccess.TreeViewNodes[CommonDataAccess.TreeViewNodes.Count - 1];
                // Get the list of referenced assemblies for the project. Subsequently create a new node that will then show them (a “root node” for the references if you want to say so). At this point the node does NOT yet get added to the collection that’s bound to the TreeView.
                IReadOnlyList<MetadataReference> projectReferences = project.MetadataReferences;
                SyntaxTreeNode referenceNode = new SyntaxTreeNode();
                referenceNode.Name = "Referenced assemblies";
                referenceNode.Type = "Reference list";
                referenceNode.SyntaxTreeNodes = new ObservableCollection<SyntaxTreeNode>();
                // Create a new node for each reference entry under the reference “root node” defined above.
                foreach (MetadataReference reference in projectReferences)
                {
                    SyntaxTreeNode refNode = new SyntaxTreeNode();
                    int refNameStart = reference.Display.LastIndexOf("\\") + 1;
                    int refNameLength = reference.Display.Length - refNameStart;
                    refNode.Name = reference.Display.Substring(refNameStart, refNameLength);
                    refNode.Type = "Reference";
                    referenceNode.SyntaxTreeNodes.Add(refNode);
                }
                // Now add the prebuild reference “root node” with the single reference nodes to the earlier defined project node (therefore creating a structure with two sublevels).
                parentProjectNode.SyntaxTreeNodes.Add(referenceNode);
                // Now go through the documents for the current project.
                foreach (Document document in project.Documents)
                {
                    // Add a subnode to the current project for the document.
                    SyntaxTreeNode TreeNode = new SyntaxTreeNode();
                    TreeNode.Name = document.Name;
                    TreeNode.Type = "File";
                    parentProjectNode.SyntaxTreeNodes.Add(TreeNode);
                    string path = document.FilePath;
                    FileStream stream = File.OpenRead(path);
                    SyntaxTree tree = CSharpSyntaxTree.ParseText(SourceText.From(stream), path: path);
                    CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();
                    // Similar to the project level, determine the node for each document now and set it as “parentNode”. So this is actually now on a sublevel (most likely the first).
                    SyntaxTreeNode actNode = parentProjectNode.SyntaxTreeNodes[parentProjectNode.SyntaxTreeNodes.Count - 1];
                    // Call the method for adding the subnodes for the current document. Passing with ref so no need to return a node.
                    getSubNodes(root, ref actNode);
                }
            }
        }
        // Simple method for getting the childs of the SyntaxTree, init the sublevel collection and adding prepared subnodes to the parent node.
        public void getSubNodes(CompilationUnitSyntax parentTree, ref SyntaxTreeNode parentNode)
        {
            ChildSyntaxList childs = parentTree.ChildNodesAndTokens();
            List<SyntaxTreeNode> nodesToAdd = iterateSubNodes(childs);
            foreach (SyntaxTreeNode node in nodesToAdd)
            {
                if (parentNode.SyntaxTreeNodes == null)
                    parentNode.SyntaxTreeNodes = new ObservableCollection<SyntaxTreeNode>();
                parentNode.SyntaxTreeNodes.Add(node);
            }
        }
        // Method for examing the kind of the current node. If no proper kind was found “recursively” searching through the nodes. Has to be improved, expanded and refactored still (dictionary could be suitable for this).
        public List<SyntaxTreeNode> iterateSubNodes (ChildSyntaxList syntaxList)
        {
            List<SyntaxTreeNode> nodesToReturn = new List<SyntaxTreeNode>();
            foreach (SyntaxNodeOrToken nodeOrToken in syntaxList)
            {
                SyntaxKind childKind = nodeOrToken.Kind();
                if (childKind == SyntaxKind.UsingDirective)
                {
                    SyntaxTreeNode tokenToAdd = new SyntaxTreeNode();
                    UsingDirectiveSyntax usingNode = (UsingDirectiveSyntax)nodeOrToken;
                    tokenToAdd = addUsing(usingNode);
                    nodesToReturn.Add(tokenToAdd);
                }
                else if (childKind == SyntaxKind.NamespaceDeclaration)
                {
                    SyntaxTreeNode tokenToAdd = new SyntaxTreeNode();
                    NamespaceDeclarationSyntax namespaceNode = (NamespaceDeclarationSyntax)nodeOrToken;
                    tokenToAdd = addNamespace(namespaceNode);
                    nodesToReturn.Add(tokenToAdd);
                }
                else
                {
                    iterateSubNodes(nodeOrToken.ChildNodesAndTokens());
                }
            }
            // Return the node (or a list of them) for further processing.
            return nodesToReturn;
        }
        // Method for defining the parameters for a NameSpaceDeclaration.
        private SyntaxTreeNode addNamespace(NamespaceDeclarationSyntax namespaceSyntax)
        {
            SyntaxTreeNode nodeToReturn = new SyntaxTreeNode();
            nodeToReturn.Name = namespaceSyntax.Name.ToString();
            nodeToReturn.Type = "Namespace Definition";
            return nodeToReturn;
        }
        // The same as for Namespace, here just for usingDirectives.
        private SyntaxTreeNode addUsing(UsingDirectiveSyntax usingSyntax)
        {
            SyntaxTreeNode nodeToReturn = new SyntaxTreeNode();
            nodeToReturn.Name = usingSyntax.Name.ToString();
            nodeToReturn.Type = usingSyntax.Kind().ToString();
            return nodeToReturn;
        }
