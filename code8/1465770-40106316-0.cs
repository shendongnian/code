    var toolList = (from pos in Configuration.List
        select new Position
        {
            ToolNumber = (int)pos.tlno,
            Tool = new Tool
            {
                ToolId = pos.tlno.ToString(),
                Step = new Step
                {
                    Position = "1",
                    MsrProgram = new MsrProgram
                    {
                        OwnerTypeFullName = "",
                        Number = GetNumber(), // <- fill in what really should be used
                        MsrRange = GetNumber() == 1 ? 1 : 0,
                        TurnoverMeasure = GetNumber() == 2 ? 1 : 0
                    }
                }
            }
        }
    );
