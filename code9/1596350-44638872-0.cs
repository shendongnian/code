    using System;
    using System.Globalization;
    CultureInfo provider = CultureInfo.InvariantCulture;
    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        Row.outDate = DateTime.ParseExact(Row.inDate,"dd-MMM-yyyy HH:mm:ss.ff",provider).ToString("dd-MM-yyyy HH:mm:ss.ff");
    }
