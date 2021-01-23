    public class MyClassItem(RequiredParam1 Param1, RequiredParam2 Param2)
    {
        if (Param1 == null) {
            throw new ArgumentNullException(nameof(Param1));
        }
        if (Param2 == null) {
            throw new ArgumentNullException(nameof(Param2));
        }
        Contract.EndContractBlock();
        /* Set Parameters here */
    }
