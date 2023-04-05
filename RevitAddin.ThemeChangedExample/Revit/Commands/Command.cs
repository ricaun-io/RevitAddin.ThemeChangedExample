using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace RevitAddin.ThemeChangedExample.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIThemeManager.CurrentTheme = UIThemeManager.CurrentTheme == UITheme.Dark ? UITheme.Light : UITheme.Dark;

            return Result.Succeeded;
        }
    }
}
