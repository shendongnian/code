    public class EmployeeFormDataRepesenter
    {
        public List<Company> Companies { get; set; }
        public List<Country> Countries { get; set; }
        public List<CastCategory> CastCategories { get; set; }
    }
    public void LoadData(EmployeeFormDataRepesenter representer)
        {
            //gender
            cbGender.DataSource = Enum.GetValues(typeof(Gender));
            //merital status
            cbMeritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            //religion 
            cbReligion.DataSource = Enum.GetValues(typeof(Religion));
            //company
            var _companies = representer.Companies;
            _companies.Insert(0, new data.Models.CompanyModels.Company { Address = new data.Models.Address(), Code = null, Name = "--Select--", BaseCurrency = new data.Models.Currency() });
            cbCompany.DataSource = _companies;
            cbCompany.DisplayMember = "Name";
            cbCompany.ValueMember = "ID";
            //citizenship
            var _citizenships = representer.Countries.Select(x => x.Citizenship).ToList();
            _citizenships.Insert(0, "--Select--");
            cbCitizenship.DataSource = _citizenships;
            cbCitizenship.DisplayMember = "Citizenship";
            //nationality
            var _nations = representer.Countries.Select(x => x.Name).ToList();
            _nations.Insert(0, "--Select--");
            cbNationality.DataSource = _nations;
            cbNationality.DisplayMember = "Name";
            //domicile
            var _domiciles = representer.Countries.Select(x => x.Name).ToList();
            _domiciles.Insert(0, "--Select--");
            cbDomicile.DataSource = _domiciles;
            cbDomicile.DisplayMember = "Name";
            //cast category
            var _casts = representer.CastCategories.Select(x => new { x.ShortText, x.Description }).Distinct().ToList();
            _casts.Insert(0, new { ShortText = "", Description = "--Select--" });
            cbCategory.DataSource = _casts;
            cbCategory.DisplayMember = "Description";
            cbCategory.ValueMember = "ShortText";
        }
    private async void btnEmplyee_Click(object sender, EventArgs e)
		{
            con = new Connection();
            Action showProgress = () => frmStatrup._progressBar.Visible = true;
            Action hideProgress = () => frmStatrup._progressBar.Visible = false;
            EmployeeFormDataRepesenter representer;
            Task<List<Company>> _taskCompany = new Task<List<Company>>(() =>
            {
                BeginInvoke(showProgress);
                var list = con.Companies.ToListAsync();
                BeginInvoke(hideProgress);
                if (list != null)
                    return list.Result;
                return null;
            });
            Task<List<Country>> _taskCountry = new Task<List<Country>>(() =>
            {
                BeginInvoke(showProgress);
                var list = con.Countries.ToListAsync();
                BeginInvoke(hideProgress);
                if (list != null)
                    return list.Result;
                return null;
            });
            Task<List<CastCategory>> _taskCasts = new Task<List<CastCategory>>(() =>
            {
                BeginInvoke(showProgress);
                var list = con.CastCategories.ToListAsync();
                BeginInvoke(hideProgress);
                if (list != null)
                    return list.Result;
                return null;
            });
            _taskCompany.Start();
            var _companies = await _taskCompany;
            _taskCountry.Start();
            var _countries = await _taskCountry;
            _taskCasts.Start();
            var _casts = await _taskCasts;
            if (_companies.Count != 0)
            {
                representer = new EmployeeFormDataRepesenter();
                representer.Companies = _companies;
                representer.Countries = _countries;
                representer.CastCategories = _casts;
            }
            else
            {
                representer = null;
            }
            if (representer != null)
            {
                frmEmployee _emp = new frmEmployee();
                _emp.LoadData(representer);
                Functions.OpenForm(_emp, this.ParentForm);
            }
		}
