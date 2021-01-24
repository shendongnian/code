    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] classArrAvail = { "A1", "B1", "B2", "C1" };
            int[] countAvailable = { 20, 5, 10, 15 };
            Chart1.Series["SeriesAvailable"].Points.DataBindXY(classArrAvail, countAvailable);
            foreach (DataPoint pt in Chart1.Series["SeriesAvailable"].Points)
            {
                if (pt.YValues[0] <= 10)
                    pt.Color = Color.Red;
                else pt.Color = Color.Green;
            }
        }
    }
