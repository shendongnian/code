        public static async Task<string[]> GetCode(IEnumerable<CodeAddressContainer> codeList, int count)
        {
            return await Task.Run<string[]>(() => codeList.AsParallel().Select(code =>
            {
                var id = code.Id;
                var asm = code.ASM;
                var address = code.Address;
                var hexCode = CompileCodeToPairedHex(asm);
                var lines = hexCode.GetNonEmptyLineCount();
                address = GetInsertionAddress(address, lines);
                string result = address + Environment.NewLine + hexCode;
                return result;
            }).ToArray());
        }
