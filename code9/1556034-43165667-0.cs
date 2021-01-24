    @{
        string firstGuaranteePolicy = Model.Bookings.Select(b => b.GuaranteePolicy).FirstOrDefault();
        bool areAllTheSame = Model.Bookings.Select(b => b.GuaranteePolicy).All(val => val == firstGuaranteePolicy);
    }
    @if (areAllTheSame)
    {
        <tfoot>
        ...
        </tfoot>
    }
