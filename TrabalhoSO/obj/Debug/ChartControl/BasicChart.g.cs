﻿#pragma checksum "..\..\..\ChartControl\BasicChart.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1BC687798C624148A830AC4CC2470346"
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
using TrabalhoSO.ChartControl;


namespace TrabalhoSO.ChartControl {
    
    
    /// <summary>
    /// BasicChart
    /// </summary>
    public partial class BasicChart : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\ChartControl\BasicChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private TrabalhoSO.ChartControl.BasicChart _this;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\ChartControl\BasicChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Controls.Border PlotAreaBorder;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\ChartControl\BasicChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Shapes.Polyline YAxisLine;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\ChartControl\BasicChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Shapes.Polyline XAxisLine;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\ChartControl\BasicChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Controls.ItemsControl PlotArea;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\ChartControl\BasicChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Controls.ItemsControl XAxis;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\ChartControl\BasicChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Controls.ItemsControl YAxis;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\ChartControl\BasicChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Controls.ItemsControl Curves;
        
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
            System.Uri resourceLocater = new System.Uri("/TrabalhoSO;component/chartcontrol/basicchart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ChartControl\BasicChart.xaml"
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
            this._this = ((TrabalhoSO.ChartControl.BasicChart)(target));
            return;
            case 2:
            this.PlotAreaBorder = ((System.Windows.Controls.Border)(target));
            
            #line 100 "..\..\..\ChartControl\BasicChart.xaml"
            this.PlotAreaBorder.SizeChanged += new System.Windows.SizeChangedEventHandler(this.PlotAreaBorder_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.YAxisLine = ((System.Windows.Shapes.Polyline)(target));
            return;
            case 4:
            this.XAxisLine = ((System.Windows.Shapes.Polyline)(target));
            return;
            case 5:
            this.PlotArea = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 6:
            this.XAxis = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 7:
            this.YAxis = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 8:
            this.Curves = ((System.Windows.Controls.ItemsControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

