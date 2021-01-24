    public void test(GetAllBankListDto input)
    {
        AsyncHelper.RunSync(() => testDeleteBank(input.bankID));
        // UpdateMsBank(input);
    }
