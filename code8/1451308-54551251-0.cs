using MvvmCross.Core.ViewModels;
using StoreChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.FilePicker;
using MvvmCross.Platform;
using MvvmCross.Plugins.File;
namespace StoreChecker.ViewModels
{
    public class AddNewBrandViewModel : MvxViewModel
    {
        private async Task BrowseFiles()
        {
            var fileData = await CrossFilePicker.Current.PickFile();
            // Do something with your file data
        }
}
