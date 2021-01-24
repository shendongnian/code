        public static class DeliveryInstructionFactory
    {
        public static Instruction Create(int type, string data)
        {
            return Create((InstructionType)type, data);
        }
        public static Instruction Create(InstructionType type, string data)
        {
            switch (type)
            {
                case InstructionType.PreferredDay:
                    return new PreferredDayInstruction(data);
                case InstructionType.ServicePoint:
                    return new ServicePointInstruction(data);
                case InstructionType.Neighbour:
                    return new NeighbourInstruction(data);
                default:
                    return null;
            }
        }
    }
