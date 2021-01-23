    public static async Task<string[]> GetCode(IEnumerable<CodeAddressContainer> codeList, int count)
    {
        var list = await codeList.ToListAsync();
        string[] stringArray = new string[count];
        Parallel.ForEach(codeList, code =>
        {
            var id = code.Id;
            var asm = code.ASM;
            var address = code.Address;
            var hexCode = CompileCodeToPairedHex(asm);
            var lines = hexCode.GetNonEmptyLineCount();
            address = GetInsertionAddress(address, lines);
            string result = address + Environment.NewLine + hexCode;
            stringArray[id] = result;
        }
        return stringArray;
    }
