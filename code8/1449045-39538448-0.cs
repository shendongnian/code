    static void Main(string[] args)
		{
			resultsEntities context = new resultsEntities();
			ResultsRepository resultsRepository = new ResultsRepository(context);
			var ma_results = resultsRepository.GetTList().Where(x => x.SubjectCode == 2); //получить результаты по математике
			IReportService reportService = new ExcelReportService();
			reportService.GenerateReport(ma_results);
		}
		public interface IReportService
		{
			void GenerateReport(IEnumerable<StudentDto> students);
		}
		public class ExcelReportService:IReportService
		{
			public void GenerateReport(IEnumerable<StudentDto> students)
			{
				Excel.Application app = new Excel.Application();
				app.DisplayAlerts = false;
				Excel.Workbook book_template = app.Workbooks.Open(@"шаблон_отчета.xlsx");
				Excel._Worksheet sheet_template = book_template.Sheets["отчет"];
				foreach (var ob in students)
				{
					//1. Создаем объкт LearnerReport из БД
					LearnerReport report = new LearnerReport
					{
						SNS = $"{ob.surname} {ob.name} {ob.SecondName}",
						SchoolName = ob.SchoolName,
						ClassName = ob.ClassName,
						TestResult5 = ob.TestResult5
					};
					//2. Экспорт объкта LearnerReport в шаблон xlsx
					sheet_template.Range["C4"].Value2 = report.SNS;
					sheet_template.Range["C5"].Value2 = report.SchoolName;
					sheet_template.Range["C6"].Value2 = report.ClassName;
					sheet_template.Range["C9"].Value2 = report.TestResult5;
					//3. Сохраняем полученный файл в .pdf на рабочем столе
					string file_name = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{report.SNS}.pdf";
					sheet_template.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, file_name);
				}
				
				book_template.Close(0);
				book_template = null;
				app.Quit();
				app = null;
			}
		}
