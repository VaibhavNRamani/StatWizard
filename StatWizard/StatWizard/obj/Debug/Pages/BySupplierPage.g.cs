﻿#pragma checksum "..\..\..\Pages\BySupplierPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "19EDD1934C7D4D73B26DF05235CACA8D21DB369F6D161C900656AB5541C47598"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StatWizard.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
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


namespace StatWizard.Pages {
    
    
    /// <summary>
    /// BySupplierPage
    /// </summary>
    public partial class BySupplierPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Pages\BySupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\BySupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelectSupplierTextblock;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\BySupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SuppliersCombobox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\BySupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QueryButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\BySupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SupplierCostTextblock;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Pages\BySupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.LineSeries Series2013;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\BySupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.LineSeries Series2014;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\BySupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WeekTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\BySupplierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WeeklyOrderCostTextblock;
        
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
            System.Uri resourceLocater = new System.Uri("/StatWizard;component/pages/bysupplierpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\BySupplierPage.xaml"
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
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Pages\BySupplierPage.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SelectSupplierTextblock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.SuppliersCombobox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.QueryButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Pages\BySupplierPage.xaml"
            this.QueryButton.Click += new System.Windows.RoutedEventHandler(this.QueryButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SupplierCostTextblock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Series2013 = ((System.Windows.Controls.DataVisualization.Charting.LineSeries)(target));
            return;
            case 7:
            this.Series2014 = ((System.Windows.Controls.DataVisualization.Charting.LineSeries)(target));
            return;
            case 8:
            this.WeekTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.WeeklyOrderCostTextblock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
