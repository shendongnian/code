      // Base list is the list I get provided with.
            List<TreeElement> newList = new List<TreeElement>();
            TreeElement root = null;
            TreeElement previousFolder = null;
            int previousdepth = -99;
            for (int i = 0; i < baseList.Count; i++)
            {
                TreeElement currentResource = baseList[i];
                if (currentResource.depth == -1 && ShowRootFolder) // The root folder.
                {
                    root = new TreeElement("Root", currentResource.depth, null);
                    // (Name, depth, parent)
                    newList.Add(root);
                    previousFolder = root;
                    previousdepth = root.depth;
                }
                else if (!ShowRootFolder && currentResource.depth <= 0)
                {
                    // If root folder is not shown, take all the children of the root folder instead.
                    if (currentResource.depth != -1)
                    {
                        previousFolder = new TreeElement(currentResource.name, currentResource.depth, null);
                        previousdepth = previousFolder.depth;
                        newList.Add(previousFolder);
                    }
                }
                else
                {
                    if (currentResource.depth > previousdepth)
                    {
                        TreeElement newResource = new TreeElement(currentResource.name, currentResource.depth, previousFolder);
                        previousFolder.children.Add(newResource);
                        previousdepth = currentResource.depth;
                        previousFolder = newResource;
                    }
                }
            }
            return newList;
