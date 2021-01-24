    public async Task<byte[]> GetRowVersionAsync<TEntity>(string id = null)
    {
        switch (typeof(TEntity))
        {
            case var type when type == typeof(Department):
                return await Department.Select(e => GetDepartmentRowVersion(Convert.ToInt32(id))).FirstOrDefaultAsync();
            case var type when type == typeof(Player):
                return await (id == null ? Player.Select(e => GetPlayerRowVersion(Guid.Empty)) : Player.Select(e => GetPlayerRowVersion(new Guid(id)))).FirstOrDefaultAsync();
            case var type when type == typeof(Address):
                return await (id == null ? Address.Select(e => GetAddressRowVersion(Guid.Empty)) : Address.Select(e => GetAddressRowVersion(new Guid(id)))).FirstOrDefaultAsync();
            default:
                return new byte[] { };
        }
    }
    public static byte[] GetPlayerRowVersion(Guid id) => null;     // Scalar function mappings.
    public static byte[] GetAddressRowVersion(Guid id) => null;    // When using an in memory database since SQL UDF functions are not mapped to any Server, so we return a null value instead of throwing an error.
    public static byte[] GetDepartmentRowVersion(int id) => null;
