﻿#pragma checksum "C:\Users\USER\Desktop\2023\DeepMind\src\DataManager\DeepMindDataManager\src\Frameworks\View\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6A39CFB82221BE1A27898FFD456CDD52F2E1F105053F8A8AC08DF17E71720910"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeepMindDataManager
{
    partial class MainWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // src\Frameworks\View\MainWindow.xaml line 23
                {
                    this.TitleBar = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 3: // src\Frameworks\View\MainWindow.xaml line 37
                {
                    this.navigationView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationView>(target);
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.navigationView).Loaded += this.Navigation_Loaded;
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.navigationView).ItemInvoked += this.NavigationView_ItemInvoked;
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.navigationView).BackRequested += this.NavView_BackRequested;
                }
                break;
            case 4: // src\Frameworks\View\MainWindow.xaml line 43
                {
                    this.navigationFrame = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Frame>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

