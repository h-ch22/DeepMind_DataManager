﻿#pragma checksum "C:\Users\USER\Desktop\2023\DeepMind\src\DataManager\DeepMindDataManager\src\Labeling\View\LabelingView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "434A311B1AE916E21075E0E3D1073EAE3C9446D48DBFAB97B8373AB1051D49F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeepMindDataManager.src.Labeling.View
{
    partial class LabelingView : 
        global::Microsoft.UI.Xaml.Controls.Page, 
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
            case 2: // src\Labeling\View\LabelingView.xaml line 13
                {
                    this.txt_noDirectory = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 3: // src\Labeling\View\LabelingView.xaml line 15
                {
                    this.mainView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 4: // src\Labeling\View\LabelingView.xaml line 32
                {
                    this.radioBtn_CL01 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.RadioButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.RadioButton)this.radioBtn_CL01).Checked += this.onRadioButtonStateChanged;
                }
                break;
            case 5: // src\Labeling\View\LabelingView.xaml line 33
                {
                    this.radioBtn_CL02 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.RadioButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.RadioButton)this.radioBtn_CL02).Checked += this.onRadioButtonStateChanged;
                }
                break;
            case 6: // src\Labeling\View\LabelingView.xaml line 34
                {
                    this.radioBtn_CL03 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.RadioButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.RadioButton)this.radioBtn_CL03).Checked += this.onRadioButtonStateChanged;
                }
                break;
            case 7: // src\Labeling\View\LabelingView.xaml line 23
                {
                    this.txt_fileName = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 8: // src\Labeling\View\LabelingView.xaml line 24
                {
                    this.img_data = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Image>(target);
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
