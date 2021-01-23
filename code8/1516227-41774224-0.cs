    //
    // Summary:
    //     Initializes a new instance of the System.DateTimeOffset structure using the specified
    //     System.DateTime value and offset.
    //
    // Parameters:
    //   dateTime:
    //     A date and time.
    //
    //   offset:
    //     The time's offset from Coordinated Universal Time (UTC).
    //
    // Exceptions:
    //   T:System.ArgumentException:
    //     dateTime.Kind equals System.DateTimeKind.Utc and offset does not equal zero.-or-dateTime.Kind
    //     equals System.DateTimeKind.Local and offset does not equal the offset of the
    //     system's local time zone.-or-offset is not specified in whole minutes.
    //
    //   T:System.ArgumentOutOfRangeException:
    //     offset is less than -14 hours or greater than 14 hours.-or-System.DateTimeOffset.UtcDateTime
    //     is less than System.DateTimeOffset.MinValue or greater than System.DateTimeOffset.MaxValue.
    public DateTimeOffset(DateTime dateTime, TimeSpan offset);
