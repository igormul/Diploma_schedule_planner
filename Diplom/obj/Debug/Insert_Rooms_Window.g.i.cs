﻿#pragma checksum "..\..\Insert_Rooms_Window.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D09EECAD151B4F86A0D6F3D7A0F12291"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Diplom;
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


namespace Diplom {
    
    
    /// <summary>
    /// Insert_Rooms_Window
    /// </summary>
    public partial class Insert_Rooms_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Insert_Rooms_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox N_TB;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Insert_Rooms_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox T_TB;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Insert_Rooms_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox C_TB;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Insert_Rooms_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OK_B;
        
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
            System.Uri resourceLocater = new System.Uri("/Diplom;component/insert_rooms_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Insert_Rooms_Window.xaml"
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
            this.N_TB = ((System.Windows.Controls.TextBox)(target));
            
            #line 10 "..\..\Insert_Rooms_Window.xaml"
            this.N_TB.GotFocus += new System.Windows.RoutedEventHandler(this.N_TB_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.T_TB = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\Insert_Rooms_Window.xaml"
            this.T_TB.GotFocus += new System.Windows.RoutedEventHandler(this.T_TB_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.C_TB = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\Insert_Rooms_Window.xaml"
            this.C_TB.GotFocus += new System.Windows.RoutedEventHandler(this.C_TB_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OK_B = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Insert_Rooms_Window.xaml"
            this.OK_B.Click += new System.Windows.RoutedEventHandler(this.OK_B_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

