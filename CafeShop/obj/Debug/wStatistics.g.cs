﻿#pragma checksum "..\..\wStatistics.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "20F649FF0A7DA2BC7DD832768F7EC49B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CafeShop {
    
    
    /// <summary>
    /// wStatistics
    /// </summary>
    public partial class wStatistics : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\wStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpXemtheoNgay;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\wStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnXemtheoNgay;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\wStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTongDoanhThuTheoNgay;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\wStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgvDoanhThuRheoNgay;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\wStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgThongtinHoadon;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\wStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnXemThongtinHoadon;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\wStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtxtShowBill;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\wStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtID;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CafeShop;component/wstatistics.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\wStatistics.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dpXemtheoNgay = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.btnXemtheoNgay = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\wStatistics.xaml"
            this.btnXemtheoNgay.Click += new System.Windows.RoutedEventHandler(this.btnXemtheoNgay_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtTongDoanhThuTheoNgay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dtgvDoanhThuRheoNgay = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.dtgThongtinHoadon = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnXemThongtinHoadon = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\wStatistics.xaml"
            this.btnXemThongtinHoadon.Click += new System.Windows.RoutedEventHandler(this.btnXemThongtinHoadon_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rtxtShowBill = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 8:
            this.txtID = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

