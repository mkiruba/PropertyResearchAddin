using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Office.Tools.Excel;
using PropertyResearchAddin.Presentation.ExcelFunctions;
using PropertyResearchAddin.Service;
using PropertyResearchAddin.Service.BO;

namespace PropertyResearchAddin.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private decimal price = 0.00M;
        private string postcode;
        private string town;
        private IZooplaService zooplaService;
        public static Workbook ExcelWorkbook { get; set; }
        public static Worksheet ExcelWorksheet { get; set; }
        public decimal Price
        {
            get => price;
            set => Set(ref price, value);
        }

        public string Postcode
        {
            get => postcode;
            set => Set(ref postcode, value);
        }
        public string Town
        {
            get => town;
            set => Set(ref town, value);
        }
        public RelayCommand GetPropertyPriceCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    GetPropertyPrice();
                });
            }
        }

        private void GetPropertyPrice()
        {
            var propertyPrices = zooplaService.GetPrice(Postcode, Town);
            BuildTable(propertyPrices);
            //ExcelApplication.ActiveCell.Value2 = "Hello";
        }

        private void BuildTable(List<PropertyDetails> propertyPrices)
        {
            //http://forum.finaquant.com/viewtopic.php?f=4&t=1276
            var table = ExcelFunction.CreateDataTable<PropertyDetails>(propertyPrices);

            //ListObject listObject = activeWorksheet.ListObjects.AddEx(SourceType: XlListObjectSourceType.xlSrcModel,
            //    Source: ExcelApplication.Cells["A1", "C2"],
            //    XlListObjectHasHeaders: XlYesNoGuess.xlYes);
            //ListObject listObject = ExcelWorkbook.ActiveSheet.ListObjects.AddEx(SourceType: XlListObjectSourceType.xlSrcModel,
            //    Source: ExcelWorkbook.ActiveSheet.Cells["A1", "C2"],
            //    XlListObjectHasHeaders: XlYesNoGuess.xlYes);
            //Microsoft.Office.Tools.Excel.Worksheet worksheet = (Microsoft.Office.Tools.Excel.Worksheet)ExcelWorkbook.ActiveSheet;
            ListObject listObject = ExcelWorksheet.Controls.AddListObject(ExcelWorksheet.Range["A1", "C2"], "listObject");
            listObject.Name = "PriceSummary";
            listObject.SetDataBinding(table);
            //activeWorksheet.ListObjects["PriceSummary"].TableStyle = "TableStyleMedium3";
            //Worksheet activeWorksheet = (Worksheet)ExcelApplication.ActiveSheet;
            //foreach (var propertyPrice in propertyPrices)
            //{
            //    activeWorksheet.Cells[1, "A"] = propertyPrice.DisplayableAddress;
            //    activeWorksheet.Cells[1, "B"] = propertyPrice.DetailsUrl;
            //    activeWorksheet.Cells[1, "C"] = propertyPrice.Price;
            //}
        }

        public MainViewModel(IZooplaService zooplaService)
        {
            this.zooplaService = zooplaService;
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}