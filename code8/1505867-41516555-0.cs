     public JsonResult GetJsTree3Data()
        {
            var marketGroups = new List<JsTree3Node>();
            var marketSubGroups = new List<JsTree3Node>();
           
            foreach (var group in GenerateGroups(connString))
            {
                var node = JsTree3Node.NewNode(group.id_str);
                node.text = group.name;
                node.state = new State(false, false, false);
                node.parentId = group.marketParentGroup;
                marketSubGroups.Add(node);
            }
            // Create our root node and ensure it is opened
            var root = new JsTree3Node()
            {
                id = Guid.NewGuid().ToString(),
                text = "Market Items",
                state = new State(true, false, false)
            };
            foreach (var group in marketSubGroups)
            {
                    var node = JsTree3Node.NewNode(group.id);
                    node.text = group.text;
                    node.state = new State(false, false, false);
                    marketGroups.Add(node);
            }
            foreach (var marketGroup in marketGroups)
            {
                foreach (var subGroup in marketSubGroups)
                {
                    if (subGroup.parentId.ToString() == marketGroup.id)
                    {
                        var subGroupNode = new JsTree3Node();
                        subGroupNode.id = subGroup.id;
                        subGroupNode.text = subGroup.text;
                        subGroupNode.state = new State(false, false, false);
                        marketGroup.children.Add(subGroupNode);
                    }
                }
            }
            root.children = marketGroups;
            
            return Json(root, JsonRequestBehavior.AllowGet);
        }
