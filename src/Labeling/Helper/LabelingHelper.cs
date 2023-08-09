using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DeepMindDataManager.src.Labeling.Helper
{
    class LabelingHelper
    {
        private Process pythonProcess;
        private ProcessStartInfo psi;
        private bool isPredictSuccess = false;

        public Task predict(string directory, string modelDir, string directory_Script, string directory_Python)
        {
            string commandText = "/c python.exe " + directory_Script + @"\main.py --dataSet " + directory + " --modelRoot " + modelDir + @"\best.pt";

            psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";

            psi.ArgumentList.Add(commandText);
            psi.WorkingDirectory = directory_Python;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;

            pythonProcess = new Process();
            pythonProcess.StartInfo = psi;
            pythonProcess.Start();

            var tcs = new TaskCompletionSource<object>();
            pythonProcess.EnableRaisingEvents = true;
            pythonProcess.Exited += new EventHandler(process_Exited);
            pythonProcess.Exited += (sender, args) => tcs.TrySetResult(null);

            return pythonProcess.HasExited ? Task.CompletedTask : tcs.Task;
        }

        private void process_Exited(object sender, EventArgs e)
        {
            Process p = (Process)sender;

            if(p.ExitCode != 0)
            {
                isPredictSuccess = false;
            }
            else
            {
                isPredictSuccess = true;
            }
        }

        public bool getPredictStatus()
        {
            return isPredictSuccess;
        }

        public string getPath(string workingDirectory)
        {
            var dirInfo = new DirectoryInfo(workingDirectory + @"\runs\detect").GetDirectories().OrderByDescending(d => d.LastWriteTimeUtc).FirstOrDefault();

            return dirInfo.FullName;
        }

        public (string, string, string, string, string, string, string, string) loadDirectory()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

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

        public (string, string) loadFile(string directory, int index)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            FileInfo[] fileInfo = dirInfo.GetFiles("*.jpg");

            return (fileInfo[index].FullName, fileInfo[index].Name);
        }

        public int getFileCount(string directory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            FileInfo[] fileInfo = dirInfo.GetFiles("*.jpg");

            return fileInfo.Length;
        }
    }
}
