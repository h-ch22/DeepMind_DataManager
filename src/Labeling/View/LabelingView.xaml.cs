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
using System.Diagnostics;
using System.Threading.Tasks;
using DeepMindDataManager.src.Labeling.Helper;
using System.Xml.Linq;

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
        private string directory_ML01;
        private string directory_ML02;
        private string directory_ML03;
        private string directory_Python;
        private string directory_Script;
        private string currentClass = "";

        private int currentIndex = 0;
        private int maxIndex = 0;

        private LabelingHelper helper = new LabelingHelper();

        public LabelingView()
        {
            (directory_CL01, directory_CL02, directory_CL03, directory_ML01, directory_ML02, directory_ML03, directory_Python, directory_Script) = helper.loadDirectory();
            currentClass = "CL01";

            this.InitializeComponent();

            if (directory_CL01 == null || directory_CL02 == null || directory_CL03 == null || directory_ML01 == null || directory_ML02 == null || directory_ML03 == null || directory_Python == null || directory_Script == null)
            {
                txt_noDirectory.Visibility = Visibility.Visible;
            }
            else
            {
                txt_noDirectory.Visibility = Visibility.Collapsed;

                (string fullName, string name) = helper.loadFile(directory_CL01, currentIndex);
                setFileName(name);

                maxIndex = helper.getFileCount(directory_CL01);
                predict(fullName, directory_ML01, name);
            }
        }

        private void showProgress()
        {
            mainView.Visibility = Visibility.Collapsed;
            progressView.Visibility = Visibility.Visible;
        }

        private void showMainView()
        {
            mainView.Visibility = Visibility.Visible;
            progressView.Visibility = Visibility.Collapsed;
        }

        private async void predict(string directory, string modelDir, string fileName)
        {
            showProgress();
            await helper.predict(directory, modelDir, directory_Script, directory_Python);

            if (helper.getPredictStatus())
            {
                var path = helper.getPath(directory_Python);
                showImage(path + @"\" + fileName);
            }
            else
            {
                showImage(directory);
            }
        }

        private void showImage(string url)
        {
            img_data.Source = new BitmapImage(new Uri(url));
            showMainView();
        }

        private void setFileName(string name)
        {
            txt_fileName.Text = name;
        }

        private void onRadioButtonStateChanged(object sender, RoutedEventArgs e)
        {
            showProgress();
            string fullName = "";
            string name = "";
            currentIndex = 0;

            if((RadioButton) sender == radioBtn_CL01)
            {
                currentClass = "CL01";
                (fullName, name) = helper.loadFile(directory_CL01, currentIndex);
                predict(fullName, directory_ML01, name);

            } else if((RadioButton) sender == radioBtn_CL02)
            {
                currentClass = "CL02";
                (fullName, name) = helper.loadFile(directory_CL02, currentIndex);
                predict(fullName, directory_ML02, name);

            } else if((RadioButton) sender == radioBtn_CL03)
            {
                currentClass = "CL03";
                (fullName, name) = helper.loadFile(directory_CL03, currentIndex);
                predict(fullName, directory_ML03, name);
            }

            setFileName(name);
        }

        private void onBtnClick(object sender, RoutedEventArgs e)
        {
            if((Button) sender == btn_Next)
            {
                if(maxIndex > currentIndex)
                {
                    showProgress();
                    currentIndex += 1;

                    string fullName = "";
                    string fileName = "";

                    switch (currentClass)
                    {
                        case "CL01":
                            (fullName, fileName) = helper.loadFile(directory_CL01, currentIndex);
                            predict(fullName, directory_ML01, fileName);
                            break;

                        case "CL02":
                            (fullName, fileName) = helper.loadFile(directory_CL02, currentIndex);
                            predict(fullName, directory_ML02, fileName);
                            break;

                        case "CL03":
                            (fullName, fileName) = helper.loadFile(directory_CL03, currentIndex);
                            predict(fullName, directory_ML03, fileName);
                            break;
                    }

                    
                }
            }

            if((Button) sender == btn_Previous)
            {
                if(currentIndex > 0)
                {
                    showProgress();
                    currentIndex -= 1;

                    string fullName = "";
                    string fileName = "";

                    switch (currentClass)
                    {
                        case "CL01":
                            (fullName, fileName) = helper.loadFile(directory_CL01, currentIndex);
                            predict(fullName, directory_ML01, fileName);
                            break;

                        case "CL02":
                            (fullName, fileName) = helper.loadFile(directory_CL02, currentIndex);
                            predict(fullName, directory_ML02, fileName);
                            break;

                        case "CL03":
                            (fullName, fileName) = helper.loadFile(directory_CL03, currentIndex);
                            predict(fullName, directory_ML03, fileName);
                            break;
                    }

                }

            }
        }
    }
}
