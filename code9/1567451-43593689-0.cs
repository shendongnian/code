    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Person p = new Person { Birthday = new DateTime(2006, 12, 21), FirstName = "Jane", LastName = "Smith" };
            Person p2 = new Person { Birthday = new DateTime(2007, 9, 11), FirstName = "Alice", LastName = "Doe" };
            lstPeople.Add(p);
            lstPeople.Add(p2);
            dgvPeople.DataSource = lstPeople;
            foreach (DataGridViewColumn col in dgvPeople.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        public List<Person> lstPeople = new List<Person>();
        /// <summary>
        /// Sort the DataGridView when Header Column is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPeople_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            SortOrder so = SortOrder.None;
            if (grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                so = SortOrder.Descending;
            }
            else
            {
                so = SortOrder.Ascending;
            }
            //set SortGlyphDirection after databinding otherwise will always be none 
            Sort(grid.Columns[e.ColumnIndex].Name, so);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so; 
        }
        /// <summary>
        /// Sort the DataGridView
        /// </summary>
        /// <param name="column"></param>
        /// <param name="sortOrder"></param>
        private void Sort(string column, SortOrder sortOrder)
        {
            switch (column)
            {
                case "FirstName":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dgvPeople.DataSource = lstPeople.OrderBy(x => x.FirstName).ToList();
                        }
                        else
                        {
                            dgvPeople.DataSource = lstPeople.OrderByDescending(x => x.FirstName).ToList();
                        }
                        break;
                    }
                case "LastName":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dgvPeople.DataSource = lstPeople.OrderBy(x => x.LastName).ToList();
                        }
                        else
                        {
                            dgvPeople.DataSource = lstPeople.OrderByDescending(x => x.LastName).ToList();
                        }
                        break;
                    }
                case "Birthday":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dgvPeople.DataSource = lstPeople.OrderBy(x => x.Birthday).ToList();
                        }
                        else
                        {
                            dgvPeople.DataSource = lstPeople.OrderByDescending(x => x.Birthday).ToList();
                        }
                        break;
                    }
            }
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
