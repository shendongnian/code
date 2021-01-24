    [AutoMapFrom(typeof(ListResultDto<CompanyListDto>))]
    public class CompanyIndexViewModel : ListResultDto<CompanyListDto>
    {
        public CompanyIndexViewModel(ListResultDto<CompanyListDto> output)
        {
            output.MapTo(this);
        }
    }
