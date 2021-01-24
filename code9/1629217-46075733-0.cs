     public class DynamicDashboards : INavigationItemSource
        {
            public List<NavigationItemAttribute> GetItems()
            {
                var items = new List<NavigationItemAttribute>
                {
                    new NavigationMenuAttribute(1000, "Dashboards", "icon-speedometer")
                };
    
                using (var connection = SqlConnections.NewByKey("Default"))
                {
                    var dashboards = connection.List<DashboardsRow>();
                    foreach (var dashboard in dashboards)
                        items.Add(new NavigationLinkAttribute(1000,
                            path: "Dashboards/" + dashboard.Descricao.Replace("/", "//"),
                            url: "~/Dashboards/DefaultDashboard?link=" + dashboard.Link,
                            permission: CadastrosPermissionKeys.General,
                            icon: "icon-speedometer"));
                }
    
                return items;
            }
        }
