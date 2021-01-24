    public static explicit operator DataRowView(VwCustomerSizes arg)
    {
        DataRowView drv = new DataRowView();
        drv.Prop1 = (Prop1Type)arg.Prop1; //of course if they need casting
        drv.Prop2 = (Prop2Type)arg.Prop2;
        drv.Prop3 = (Prop3Type)arg.Prop3;
        . . .
        drv.PropN = (PropNType)arg.PropN;
        return drv;
    }
