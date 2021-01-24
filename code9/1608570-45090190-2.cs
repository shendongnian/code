    public class SourceClass
    {
        public int PercentComplete { get; set; }
        public DateTime? BillerStartDateTime { get; set; }
    }
    public class TargetClass
    {
        public string ProgressBarCssClass { get; set; }
    }
    
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // arrange - configure the automapper
            Mapper.Initialize((config =>
            {
                config.CreateMap<SourceClass, TargetClass>()
                    .ForMember(
                        dest => dest.ProgressBarCssClass, 
                        opt => opt.MapFrom(src =>  DetermineProgressBarState(src))
                    );
            }));
            
            // arrange - create a 
            var source = new SourceClass() { PercentComplete = 100 };
            
            // act - map source to target
            var target = Mapper.Map<TargetClass>(source);
            
            // assert - verify the result
            target.ProgressBarCssClass.Should().Be("progress-bar-success");
        }
        
        private string DetermineProgressBarState(SourceClass source)
        {
            if (source.PercentComplete == 100) return "progress-bar-success";
            var MaxDaysInDataEntry = 42; // missing in your sample
            return DateTime.Now.Subtract(source.BillerStartDateTime ?? DateTime.Now).TotalDays > MaxDaysInDataEntry 
                ? "progress-bar-partial" 
                : null;
        }
    }
