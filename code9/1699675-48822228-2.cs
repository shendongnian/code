        public static class TableRowListExtensions
        {
            public static SomePage.GroupsRow GetByName(this TableRowList<SomePage.GroupsRow, SomePage> rowList, string name)
            {
                return rowList.GetByXPathCondition(name, $".//span[contains(concat(' ', normalize-space(@class), ' '), ' item-name ')][normalize-space(.) = '{name}']");
            }
        }
    
    And then use it in the test:
    
        _page.Inventory.Rows.GetByName("some inventory")
    
    It should be fast and accurate.
