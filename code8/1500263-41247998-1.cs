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
                               opts => opts.MapFrom(src => src.VoteAnswerOptions));
				config.CreateMap<CreateVoteQuestionViewModel, VoteQuestion>()
					.ForMember(dest => dest.VoteAnswerOptions, 
                               opts => opts.MapFrom(src => src.PossibleAnswers));
			});
			var voteQuestion = new VoteQuestion {
				VoteAnswerOptions = new List<VoteAnswerOption> {
					new VoteAnswerOption { Answer = "Correct" }
				}
			};
			var newQuestion = Mapper.Map<VoteQuestion, CreateVoteQuestionViewModel>(voteQuestion);
			newQuestion.PossibleAnswers.Count.Should().Be(1);
			newQuestion.PossibleAnswers.Single().Answer.Should().Be("Correct");
			var vm = new CreateVoteQuestionViewModel {
				PossibleAnswers = new List<VoteAnswerOptionViewModel> {
					new VoteAnswerOptionViewModel {Answer = "Spot on"}
				}
			};
			var q = Mapper.Map<CreateVoteQuestionViewModel, VoteQuestion>(vm);
			q.VoteAnswerOptions.Count.Should().Be(1);
			q.VoteAnswerOptions.Single().Answer.Should().Be("Spot on");
		}
	}
