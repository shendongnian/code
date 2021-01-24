    class Builder2
    {
        public Builder2(MyBuilder builder)
        {
            _thing1 = builder.Thing1;
            AddThing2();
        }
        public XXX AddMyService2RequiresThing2()
        {
            ...
        }
    }
