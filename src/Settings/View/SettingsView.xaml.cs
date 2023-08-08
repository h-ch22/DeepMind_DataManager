using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Storage;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DeepMindDataManager.src.Settings.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsView : Page
    {
        private string directory_CL01 = "";
        private string directory_CL02 = "";
        private string directory_CL03 = "";
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public SettingsView()
        {
            this.InitializeComponent();

            (directory_CL01, directory_CL02, directory_CL03) = loadSettings();

            txt_CL01_directory.Text = directory_CL01;
            txt_CL02_directory.Text = directory_CL02;
            txt_CL03_directory.Text = directory_CL03;
        }

        private (string, string, string) loadSettings()
        {
            string directory_CL01 = localSettings.Values["dataDirectory_CL01"] as string;
            string directory_CL02 = localSettings.Values["dataDirectory_CL02"] as string;
            string directory_CL03 = localSettings.Values["dataDirectory_CL03"] as string;

            return (directory_CL01, directory_CL02, directory_CL03);
        }

        private async void onCL01BtnCliick(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
            folderPicker.FileTypeFilter.Add("*");

            var hwnd = WindowNative.GetWindowHandle(App.window);

            InitializeWithWindow.Initialize(folderPicker, hwnd);

            var folder = await folderPicker.PickSingleFolderAsync();

            if (folder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                txt_CL01_directory.Text = folder.Path;
                localSettings.Values["dataDirectory_CL01"] = folder.Path;
            }
        }

        private async void onCL02BtnClick(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
            folderPicker.FileTypeFilter.Add("*");

            var hwnd = WindowNative.GetWindowHandle(App.window);

            InitializeWithWindow.Initialize(folderPicker, hwnd);

            var folder = await folderPicker.PickSingleFolderAsync();

            if (folder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                txt_CL02_directory.Text = folder.Path;
                localSettings.Values["dataDirectory_CL02"] = folder.Path;
            }
        }

        private async void onCL03BtnClick(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
            folderPicker.FileTypeFilter.Add("*");

            var hwnd = WindowNative.GetWindowHandle(App.window);

            InitializeWithWindow.Initialize(folderPicker, hwnd);

            var folder = await folderPicker.PickSingleFolderAsync();

            if (folder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                txt_CL03_directory.Text = folder.Path;
                localSettings.Values["dataDirectory_CL03"] = folder.Path;
            }
        }
    }
}
