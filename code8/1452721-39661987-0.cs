    public static class OperationTypeEnumExtensions
    {
        public static OperationTypeEnum ToOperationTypeEnum(this int val)
        {
            switch (val)
            {
                case (int) OperatinTypeEnum.Sale:
                    return OperationTypeEnum.Sale;
                cast (int) OperationTypeEnum.Auth:
                    return OperationTypeenum.Auth;
                 default:
                    return OperationTypeEnum.@_none;
            }
        }
    }
