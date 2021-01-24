    public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Converter<TInput, TOutput> converter)
    {
        if (array == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
        }
        if (converter == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.converter);
        }
        Contract.Ensures(Contract.Result<TOutput[]>() != null);
        Contract.Ensures(Contract.Result<TOutput[]>().Length == array.Length);
        Contract.EndContractBlock();
        TOutput[] newArray = new TOutput[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = converter(array[i]);
        }
        return newArray;
    }
