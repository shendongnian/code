    public class StudentAssesmentPage : BasePage<StudentAssesmentPageObjectRepository>
    {
        public StudentAssesmentPage(IWebDriver driver) : base(driver, new StudentAssesmentPageObjectRepository(driver))
        {
            base.WaitForLoadingToStop();
        }
    }
