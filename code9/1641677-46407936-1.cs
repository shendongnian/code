    class InteractionProgram {
        public static Expression<Func<InteractionProgram,bool>> IsAvailable {get;} =
            i => i.Eligibility.ProgramType == InteractionProgramTypes.Available;
        ... // other members of the class
    }
    ...
    var res = ctx.InteractionPrograms.Where(InteractionProgram.IsAvailable);
