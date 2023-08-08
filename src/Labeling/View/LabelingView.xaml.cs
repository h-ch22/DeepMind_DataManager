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
using WinRT;
using Microsoft.UI.Xaml.Media.Imaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DeepMindDataManager.src.Labeling.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LabelingView : Page
    {
        private string directory_CL01;
        private string directory_CL02;
        private string directory_CL03;

        public LabelingView()
        {
            (directory_CL01, directory_CL02, directory_CL03) = loadDirectory();

            this.InitializeComponent();

            if (directory_CL01 != null && directory_CL02 != null && directory_CL03 != null)
            {
                txt_noDirectory.Visibility = Visibility.Collapsed;
                mainView.Visibility = Visibility.Visible;
            }
            else
            {
                txt_noDirectory.Visibility = Visibility.Visible;
                mainView.Visibility = Visibility.Collapsed;
            }

            (string fullName, string name) = loadFile(directory_CL01, 0);
            txt_fileName.Text = name;
            img_data.Source = new BitmapImage(new Uri(fullName));
        }

        private (string, string, string) loadDirectory()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            string directory_CL01 = localSettings.Values["dataDirectory_CL01"] as string;
            string directory_CL02 = localSettings.Values["dataDirectory_CL02"] as string;
            string directory_CL03 = localSettings.Values["dataDirectory_CL03"] as string;

            return (directory_CL01, directory_CL02, directory_CL03);
        }

        private (string, string) loadFile(string directory, int index)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            FileInfo[] fileInfo = dirInfo.GetFiles("*.jpg");

            return (fileInfo[index].FullName, fileInfo[index].Name);
        }

        private void onRadioButtonStateChanged(object sender, RoutedEventArgs e)
        {
            string fullName = "";
            string name = "";
            if((RadioButton) sender == radioBtn_CL01)
            {
                (fullName, name) = loadFile(directory_CL01, 0);

            } else if((RadioButton) sender == radioBtn_CL02)
            {
                (fullName, name) = loadFile(directory_CL02, 0);

            } else if((RadioButton) sender == radioBtn_CL03)
            {
                (fullName, name) = loadFile(directory_CL03, 0);
            }

            txt_fileName.Text = name;
            img_data.Source = new BitmapImage(new Uri(fullName));
        }
    }
}
