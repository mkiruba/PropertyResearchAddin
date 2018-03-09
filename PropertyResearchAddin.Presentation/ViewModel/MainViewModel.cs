using System.Collections.Generic;
using System.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Office.Interop.Excel;
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
        public static Application ExcelApplication { get; set; }
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
            //System.Data.DataTable table = new System.Data.DataTable();
            //DataColumn column1 = new DataColumn("Address", typeof(string));
            //DataColumn column2 = new DataColumn("UrlLink", typeof(string));
            //DataColumn column3 = new DataColumn("Price", typeof(decimal));

            //table.Columns.Add(column1);
            //table.Columns.Add(column2);
            //table.Columns.Add(column3);
            //DataRow row;
            //foreach (var propertyPrice in propertyPrices)
            //{
            //    row = table.NewRow();
            //    row["Address"] = propertyPrice.DisplayableAddress;
            //    row["UrlLink"] = propertyPrice.DetailsUrl;
            //    row["Price"] = propertyPrice.Price;
            //    table.Rows.Add(row);
            //}
            //Worksheet activeWorksheet = (Worksheet) ExcelApplication.ActiveSheet;

            //ListObject listObject = activeWorksheet.ListObjects.AddEx(SourceType: XlListObjectSourceType.xlSrcRange, 
            //    Source: ExcelApplication.Cells["A1", "C2"],
            //    XlListObjectHasHeaders: XlYesNoGuess.xlYes);
            //listObject.Name = "PriceSummary";

            //activeWorksheet.ListObjects["PriceSummary"].TableStyle = "TableStyleMedium3";
            Worksheet activeWorksheet = (Worksheet)ExcelApplication.ActiveSheet;
            foreach (var propertyPrice in propertyPrices)
            {
                activeWorksheet.Cells[1, "A"] = propertyPrice.DisplayableAddress;
                activeWorksheet.Cells[1, "B"] = propertyPrice.DetailsUrl;
                activeWorksheet.Cells[1, "C"] = propertyPrice.Price;
            }
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