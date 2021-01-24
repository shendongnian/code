    private MyParamType _myParameter;
    public override void Init(object initData)
    {
        base.Init(initData);
        var param = initData as MyParamType;
        if (param != null)
        {
            _myParameter = param;
        }
    }
