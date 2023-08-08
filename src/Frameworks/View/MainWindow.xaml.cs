using DeepMindDataManager.src.Labeling.View;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DeepMindDataManager
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.InitializeComponent();
            SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.BaseAlt };
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(TitleBar);

        }

        private void Navigation_Loaded(object sender, RoutedEventArgs e)
        {
            navigationFrame.Navigated += On_Navigated;
            navigationView.SelectedItem = navigationView.MenuItems[0];
            navigate(typeof(LabelingView), new EntranceNavigationTransitionInfo());
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                navigate(typeof(src.Settings.View.SettingsView), args.RecommendedNavigationTransitionInfo);
            } else if (args.InvokedItemContainer != null)
            {
                Type navPageType = Type.GetType(args.InvokedItemContainer.Tag.ToString());
                navigate(navPageType, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_BackRequested(NavigationView sender,
                                   NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }

        private bool TryGoBack()
        {
            if (!navigationFrame.CanGoBack)
                return false;

            if (navigationView.IsPaneOpen &&
                (navigationView.DisplayMode == NavigationViewDisplayMode.Compact ||
                 navigationView.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;

            navigationFrame.GoBack();
            return true;
        }


        private void navigate(Type navPageType, NavigationTransitionInfo transitionInfo) {
            Type preNavPageType = navigationFrame.CurrentSourcePageType;

            if(navPageType is not null && !Type.Equals(preNavPageType, navPageType))
            {
                navigationFrame.Navigate(navPageType, null, transitionInfo);
            }
        }

        private void On_Navigated(object sender, NavigationEventArgs e) {
            navigationView.IsBackEnabled = navigationFrame.CanGoBack;

            if(navigationFrame.SourcePageType == typeof(src.Settings.View.SettingsView))
            {
                navigationView.SelectedItem = (NavigationViewItem)navigationView.SettingsItem;
                navigationView.Header = "¼³Á¤";
            }

            else if (navigationFrame.SourcePageType != null)
            {
                navigationView.SelectedItem = navigationView.MenuItems.OfType<NavigationViewItem>().First(i => i.Tag.Equals(navigationFrame.SourcePageType.FullName.ToString()));
                navigationView.Header = ((NavigationViewItem)navigationView.SelectedItem)?.Content?.ToString();
            }
        }
    }
}
