﻿#pragma checksum "C:\Users\boarf\Desktop\Visual Studio Workspace\Repos new\EstateZoningApp\Views\ShellPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D98F2929AD8E6520E919D1884078A13ED4193DD0C57F6B2B061B941F9AA413ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstateZoningApp.Views
{
    partial class ShellPage : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_Primitives_ButtonBase_Command(global::Microsoft.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_MenuFlyoutItem_Command(global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ShellPage_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IShellPage_Bindings
        {
            private global::EstateZoningApp.Views.ShellPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.AppBarButton obj4;
            private global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem obj6;
            private global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem obj7;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj4CommandDisabled = false;
            private static bool isobj6CommandDisabled = false;
            private static bool isobj7CommandDisabled = false;

            public ShellPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 44 && columnNumber == 27)
                {
                    isobj4CommandDisabled = true;
                }
                else if (lineNumber == 36 && columnNumber == 74)
                {
                    isobj6CommandDisabled = true;
                }
                else if (lineNumber == 32 && columnNumber == 69)
                {
                    isobj7CommandDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4: // Views\ShellPage.xaml line 40
                        this.obj4 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                        break;
                    case 6: // Views\ShellPage.xaml line 36
                        this.obj6 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                        break;
                    case 7: // Views\ShellPage.xaml line 32
                        this.obj7 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IShellPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::EstateZoningApp.Views.ShellPage>(newDataRoot);
                    return true;
                }
                return false;
            }

            public void Activated(object obj, global::Microsoft.UI.Xaml.WindowActivatedEventArgs data)
            {
                this.Initialize();
            }

            public void Loading(global::Microsoft.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::EstateZoningApp.Views.ShellPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::EstateZoningApp.ViewModels.ShellViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_MenuSettingsCommand(obj.MenuSettingsCommand, phase);
                        this.Update_ViewModel_MenuViewsMainCommand(obj.MenuViewsMainCommand, phase);
                        this.Update_ViewModel_MenuFileExitCommand(obj.MenuFileExitCommand, phase);
                    }
                }
            }
            private void Update_ViewModel_MenuSettingsCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ShellPage.xaml line 40
                    if (!isobj4CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj4, obj, null);
                    }
                }
            }
            private void Update_ViewModel_MenuViewsMainCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ShellPage.xaml line 36
                    if (!isobj6CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_MenuFlyoutItem_Command(this.obj6, obj, null);
                    }
                }
            }
            private void Update_ViewModel_MenuFileExitCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ShellPage.xaml line 32
                    if (!isobj7CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_MenuFlyoutItem_Command(this.obj7, obj, null);
                    }
                }
            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\ShellPage.xaml line 1
                {
                    global::Microsoft.UI.Xaml.Controls.Page element1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Page>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Page)element1).Loaded += this.OnLoaded;
                    ((global::Microsoft.UI.Xaml.Controls.Page)element1).Unloaded += this.OnUnloaded;
                }
                break;
            case 2: // Views\ShellPage.xaml line 17
                {
                    this.AppTitleBar = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 3: // Views\ShellPage.xaml line 56
                {
                    this.NavigationFrame = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Frame>(target);
                }
                break;
            case 4: // Views\ShellPage.xaml line 40
                {
                    this.ShellMenuBarSettingsButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)this.ShellMenuBarSettingsButton).PointerEntered += this.ShellMenuBarSettingsButton_PointerEntered;
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)this.ShellMenuBarSettingsButton).PointerExited += this.ShellMenuBarSettingsButton_PointerExited;
                }
                break;
            case 5: // Views\ShellPage.xaml line 45
                {
                    this.ShellMenuBarSettingsButtonIcon = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AnimatedIcon>(target);
                }
                break;
            case 8: // Views\ShellPage.xaml line 19
                {
                    this.AppTitleBarText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
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
            switch(connectionId)
            {
            case 1: // Views\ShellPage.xaml line 1
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    ShellPage_obj1_Bindings bindings = new ShellPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}
