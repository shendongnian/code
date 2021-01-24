    // <summary>
    // Given a store datareader and a member of an edmType, find the column ordinal
    // in the datareader with the name of the member.
    // </summary>
    private static int GetMemberOrdinalFromReader(
        DbDataReader storeDataReader, EdmMember member, EdmType currentType,
        Dictionary<string, FunctionImportReturnTypeStructuralTypeColumnRenameMapping> renameList)
    {
        int result;
        var memberName = GetRenameForMember(member, currentType, renameList);
    
        if (!TryGetColumnOrdinalFromReader(storeDataReader, memberName, out result))
        {
            throw new EntityCommandExecutionException(
                Strings.ADP_InvalidDataReaderMissingColumnForType(
                    currentType.FullName, member.Name));
        }
        return result;
    }
