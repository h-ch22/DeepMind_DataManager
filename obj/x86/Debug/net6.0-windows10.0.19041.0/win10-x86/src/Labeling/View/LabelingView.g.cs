﻿#pragma checksum "C:\Users\USER\Desktop\2023\DeepMind\src\DataManager\DeepMindDataManager\src\Labeling\View\LabelingView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A305BEA84101D71DCCFE7FCED42469182BE20AD31DDE672CC3B20310A0CF9685"
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
            case 2: // src\Labeling\View\LabelingView.xaml line 11
                {
                    this.LabelingPanel = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.StackPanel>(target);
                }
                break;
            case 3: // src\Labeling\View\LabelingView.xaml line 13
                {
                    this.txt_noDirectory = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 4: // src\Labeling\View\LabelingView.xaml line 14
                {
                    this.progressView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ProgressRing>(target);
                }
                break;
            case 5: // src\Labeling\View\LabelingView.xaml line 17
                {
                    this.mainView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 6: // src\Labeling\View\LabelingView.xaml line 61
                {
                    this.btn_Previous = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.btn_Previous).Click += this.onBtnClick;
                }
                break;
            case 7: // src\Labeling\View\LabelingView.xaml line 63
                {
                    this.btn_Next = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.btn_Next).Click += this.onBtnClick;
                }
                break;
            case 8: // src\Labeling\View\LabelingView.xaml line 49
                {
                    this.item1_1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.CheckBox>(target);
                }
                break;
            case 9: // src\Labeling\View\LabelingView.xaml line 50
                {
                    this.item1_2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.CheckBox>(target);
                }
                break;
            case 10: // src\Labeling\View\LabelingView.xaml line 41
                {
                    this.item1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.CheckBox>(target);
                }
                break;
            case 11: // src\Labeling\View\LabelingView.xaml line 42
                {
                    this.item2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.CheckBox>(target);
                }
                break;
            case 12: // src\Labeling\View\LabelingView.xaml line 34
                {
                    this.radioBtn_CL01 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.RadioButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.RadioButton)this.radioBtn_CL01).Checked += this.onRadioButtonStateChanged;
                }
                break;
            case 13: // src\Labeling\View\LabelingView.xaml line 35
                {
                    this.radioBtn_CL02 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.RadioButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.RadioButton)this.radioBtn_CL02).Checked += this.onRadioButtonStateChanged;
                }
                break;
            case 14: // src\Labeling\View\LabelingView.xaml line 36
                {
                    this.radioBtn_CL03 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.RadioButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.RadioButton)this.radioBtn_CL03).Checked += this.onRadioButtonStateChanged;
                }
                break;
            case 15: // src\Labeling\View\LabelingView.xaml line 25
                {
                    this.txt_fileName = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            case 16: // src\Labeling\View\LabelingView.xaml line 26
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

