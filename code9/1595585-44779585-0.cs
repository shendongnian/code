    public async static Task DeleteProjectFile(this Company companies)
        {
            var file = await GetCompanyFile(companies.CompanyName);
            if (file == null)
            {
                var folder = await GlobalFolder();
                file = await folder.CreateFileAsync(companies.CompanyName + GlobalFileExtension, CreationCollisionOption.ReplaceExisting);
            }
                companies.ProjectsListed.RemoveAt(0);
        }
