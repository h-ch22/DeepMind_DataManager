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
using DeepMindDataManager.src.Settings.Helper;

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
        private string directory_ML01 = "";
        private string directory_ML02 = "";
        private string directory_ML03 = "";
        private string directory_Python = "";
        private string directory_Script = "";
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private SettingsHelper helper = new SettingsHelper();

        public SettingsView()
        {
            this.InitializeComponent();

            (directory_CL01, directory_CL02, directory_CL03, directory_ML01, directory_ML02, directory_ML03, directory_Python, directory_Script) = loadSettings();

            txt_CL01_directory.Text = directory_CL01;
            txt_CL02_directory.Text = directory_CL02;
            txt_CL03_directory.Text = directory_CL03;
            txt_ML01_directory.Text = directory_ML01;
            txt_ML02_directory.Text = directory_ML02;
            txt_ML03_directory.Text = directory_ML03;
            txt_Python_directory.Text = directory_Python;
            txt_script_directory.Text = directory_Script;
        }

        private (string, string, string, string, string, string, string, string) loadSettings()
        {
            string directory_CL01 = localSettings.Values["dataDirectory_CL01"] as string;
            string directory_CL02 = localSettings.Values["dataDirectory_CL02"] as string;
            string directory_CL03 = localSettings.Values["dataDirectory_CL03"] as string;
            string directory_ML01 = localSettings.Values["dataDirectory_ML01"] as string;
            string directory_ML02 = localSettings.Values["dataDirectory_ML02"] as string;
            string directory_ML03 = localSettings.Values["dataDirectory_ML03"] as string;
            string directory_Python = localSettings.Values["dataDirectory_Python"] as string;
            string directory_Script = localSettings.Values["dataDirectory_Script"] as string;

            return (directory_CL01, directory_CL02, directory_CL03, directory_ML01, directory_ML02, directory_ML03, directory_Python, directory_Script);
        }

        private void changeText(TextBlock text, string textValue)
        {
            text.Text = textValue;
        }

        private async void onBtnClick(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
            folderPicker.FileTypeFilter.Add("*");

            var hwnd = WindowNative.GetWindowHandle(App.window);

            InitializeWithWindow.Initialize(folderPicker, hwnd);

            var folder = await folderPicker.PickSingleFolderAsync();
            var key = "";

            if (folder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);

                if((Button) sender == btn_setData_CL01)
                {
                    changeText(txt_CL01_directory, folder.Path);
                    key = "dataDirectory_CL01";
                }
                else if((Button) sender == btn_setData_CL02)
                {
                    changeText(txt_CL02_directory, folder.Path);
                    key = "dataDirectory_CL02";
                }
                else if ((Button)sender == btn_setData_CL03)
                {
                    changeText(txt_CL03_directory, folder.Path);
                    key = "dataDirectory_CL03";
                }
                else if ((Button)sender == btn_setData_ML01)
                {
                    changeText(txt_ML01_directory, folder.Path);
                    key = "dataDirectory_ML01";
                }
                else if ((Button)sender == btn_setData_ML02)
                {
                    changeText(txt_ML02_directory, folder.Path);
                    key = "dataDirectory_ML02";
                }
                else if ((Button)sender == btn_setData_ML03)
                {
                    changeText(txt_ML03_directory, folder.Path);
                    key = "dataDirectory_ML03";
                }
                else if ((Button)sender == btn_setData_Python)
                {
                    changeText(txt_Python_directory, folder.Path);
                    key = "dataDirectory_Python";
                }
                else if((Button)sender == btn_setData_Script) {
                    changeText(txt_script_directory, folder.Path);
                    key = "dataDirectory_Script";
                }

                helper.setData(key, folder.Path);
            }
        }
    }
}
