	public class VoteQuestion {
		public virtual ICollection<VoteAnswerOption> VoteAnswerOptions { get; set; }
	}
	public class CreateVoteQuestionViewModel {
		public List<VoteAnswerOptionViewModel> PossibleAnswers { get; set; }
	}
	public class VoteAnswerOption {
		public string Answer { get; set; }
	}
	public class VoteAnswerOptionViewModel {
		public string Answer { get; set; }
	}
	[TestFixture]
	public class SOTests {
		[Test]
		public void Test_41247396() {
			Mapper.Initialize(config => {
				config.CreateMap<VoteAnswerOption, VoteAnswerOptionViewModel>().ReverseMap();
				config.CreateMap<VoteQuestion, CreateVoteQuestionViewModel>()
					.ForMember(dest => dest.PossibleAnswers, 
                               opts => opts.MapFrom(src => src.VoteAnswerOptions))
					.ReverseMap();
			});
			var voteQuestion = new VoteQuestion {
				VoteAnswerOptions = new List<VoteAnswerOption> {
					new VoteAnswerOption {
						Answer = "Correct"
					}
				}
			};
			var newQuestion = Mapper.Map<VoteQuestion, CreateVoteQuestionViewModel>(voteQuestion);
			newQuestion.PossibleAnswers.Count.Should().Be(1);
			newQuestion.PossibleAnswers.Single().Answer.Should().Be("Correct");
		}
	}
