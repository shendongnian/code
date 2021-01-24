    public static class Expand {
        public static string[] GetMembersToExpandNames(ODataQueryOptions options) {
            return GetExpandPropertyPaths(GetExpandItems(options?.SelectExpand?.SelectExpandClause)).ToArray();
        }
        private static IEnumerable<string> GetExpandPropertyPaths(IEnumerable<ExpandedNavigationSelectItem> items, string prefix = "") {
            foreach(var item in items) {
                foreach(var res in GetExpandPropertyPaths(item, prefix)) {
                    yield return res;
                }
            }
        }
        private static IEnumerable<string> GetExpandPropertyPaths(ExpandedNavigationSelectItem item, string prefix = "") {
            var curPropName = item.NavigationSource.Name;
            var nestedExpand = GetExpandItems(item.SelectAndExpand).ToArray();
            if(nestedExpand.Count() > 0) {
                foreach(var res in GetExpandPropertyPaths(nestedExpand, $"{prefix}{curPropName}.")) {
                    yield return res;
                }
            } else {
                yield return $"{prefix}{curPropName}";
            }
        }
        private static IEnumerable<ExpandedNavigationSelectItem> GetExpandItems(SelectExpandClause sec) {
            if(sec != null) {
                var res = sec?.SelectedItems?.OfType<ExpandedNavigationSelectItem>();
                if(res != null) {
                    return res;
                }
            }
            return new ExpandedNavigationSelectItem[0];
        }
    }
