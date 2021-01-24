    [AutoMapFrom(typeof(ListResultDto<CompanyListDto>))]
    public class CompanyIndexViewModel
    {
        public IReadOnlyList<CompanyListDto> Companies { get; }
        
        public CompanyIndexViewModel(IReadOnlyList<CompanyListDto> companies)
        {
            Companies = companies;
        }
    }
