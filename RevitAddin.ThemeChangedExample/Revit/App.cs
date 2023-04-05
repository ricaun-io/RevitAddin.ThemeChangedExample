using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System;

namespace RevitAddin.ThemeChangedExample.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        private static RibbonItem ribbonItem;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("ThemeExample");
            ribbonItem = ribbonPanel.CreatePushButton<Commands.Command>()
                .SetLargeImage(Properties.Resources.Revit.GetBitmapSource());

            UpdateRibbonButton(UIThemeManager.CurrentTheme == UITheme.Dark);

            application.ThemeChanged += Application_ThemeChanged;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();

            application.ThemeChanged -= Application_ThemeChanged;

            return Result.Succeeded;
        }

        const string DarkImage = "/UIFrameworkRes;component/Ribbon/ThemedImages/canvas_toggle/canvas_toggle_32_dark.png";
        const string LightImage = "/UIFrameworkRes;component/Ribbon/ThemedImages/canvas_toggle/canvas_toggle_32_light.png";

        private static void UpdateRibbonButton(bool dark)
        {
            var text = dark ? "Light" : "Dark";
            ribbonItem.SetText(text);
            ribbonItem.SetToolTip($"Change Revit theme to {text}");
            ribbonItem.SetLargeImage(dark ? DarkImage : LightImage);
        }

        private void Application_ThemeChanged(object sender, Autodesk.Revit.UI.Events.ThemeChangedEventArgs e)
        {
            UpdateRibbonButton(UIThemeManager.CurrentTheme == UITheme.Dark);
        }

    }

}