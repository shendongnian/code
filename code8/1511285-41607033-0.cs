    private void BuildAndApplyBindingContext(int listId)
    {
        int? listIdNullable = listId;
        realm.All<MemberInventoryItem>()
            .Where(i => i.InventoryListId == listIdNullable)
            ...
