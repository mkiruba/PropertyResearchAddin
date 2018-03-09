using Microsoft.Office.Core;
using PropertyResearchAddin.Presentation.ViewModel;
using Microsoft.Office.Tools;
using CustomTaskPane = Microsoft.Office.Tools.CustomTaskPane;

namespace PropertyResearchAddin
{
    public partial class ThisAddIn
    {
        private PropertyResearchControl propertyResearchControl;
        private CustomTaskPane propertyResearchCtp;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            propertyResearchControl = new PropertyResearchControl();
            propertyResearchCtp = this.CustomTaskPanes.Add(propertyResearchControl, "Property Research Pane");
            propertyResearchCtp.Visible = true;
            propertyResearchCtp.Width = 500;
            MainViewModel.ExcelWorkbook =
                Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveWorkbook);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
