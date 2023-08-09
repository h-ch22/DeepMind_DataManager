using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DeepMindDataManager.src.Settings.Helper
{
    class SettingsHelper
    {
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public void setData(string key, string value)
        {
            localSettings.Values[key] = value;
        }
    }
}
