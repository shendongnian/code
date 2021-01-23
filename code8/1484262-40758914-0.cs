     private IEnumerable<MenuNodeDTO> GetSortedNodes(Menu menu, MenuNode node)
            {
                List<MenuNodeDTO> items = new List<MenuNodeDTO>();
    
                var nodes = node != null ? node.ChildMenuNodes : menu.MenuNodes;
                var nextNode = node == null
                    ? nodes.Where(c => c.PreviousNodeId == null && c.ParentNodeId == null).FirstOrDefault()
                    : nodes.Where(c => c.ParentNodeId == node.Id && c.PreviousNodeId == null).FirstOrDefault();
    
                while (nextNode != null)
                {
                    MenuNodeDTO tmpMenuNode = new MenuNodeDTO();
                    tmpMenuNode.MenuNodeDtoId = nextNode.Id;
                    tmpMenuNode.MenuItemCode = nextNode?.MenuItem?.Code;
                    tmpMenuNode.ChildMenuNodes = this.GetSortedNodes(menu, nextNode).ToList();
                    tmpMenuNode.MenuSettings = GetMenuSettings(nextNode).ToList();
                    items.Add(tmpMenuNode);
                    if (!nextNode.NextNodeId.HasValue) break;
                    nextNode = nextNode.NextNode;
                }
                return items;
            }
