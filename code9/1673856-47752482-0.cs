    var manualExpr = Expression.Lambda<Func<Transfer, bool>>(
        body: Expression.AndAlso(
            left: Expression.Equal(Expression.Property(param, nameof(Transfer.DestinationFromId)),
               // instead of using direct constant value,
               // we build expression transferDto.DestinationFromId
               Expression.PropertyOrField(Expression.Constant(transferDto), nameof(transferDto.DestinationFromId))),
            right: Expression.Equal(Expression.Property(param, nameof(Transfer.DestinationToId)),
               // instead of using direct constant value,
               // we build expression transferDto.DestinationToId
               Expression.PropertyOrField(Expression.Constant(transferDto), nameof(transferDto.DestinationToId)))
        ),
        parameters: param
    );
