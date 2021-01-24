    public class Mutation : ObjectGraphType
    {
        public Mutation()
        {
            Name = "Mutation";
            Field<ListGraphType<HtStaticAlarmType>>(
                "registerStaticAlarms",
                arguments: new QueryArguments(
                    new QueryArgument<ListGraphType<HtStaticAlarmInputType>>
                    {
                        Name = "params"
                    }
                ),
                resolve: context =>
                {
                    List<HtStaticAlarmInputTypeParams> paramses = context.GetArgument<List<HtStaticAlarmInputTypeParams>>("params");
                    List<HtStaticAlarmBase> list = new List<HtStaticAlarmBase>();
                    foreach (HtStaticAlarmInputTypeParams p in paramses)
                    {
                        list.Add(HtAlarmManager.Create(p.Origin, (EHtAlarmClassType)Enum.Parse(typeof(EHtAlarmClassType), p.AlarmClass.ToString()), p.AlarmGroup, p.Station, (HtErrorCode)Enum.Parse(typeof(HtErrorCode), p.ErrorCode.ToString()), p.Message, p.Number));
                    }
                    
                    return list;
                }
            );            
        }
    }
