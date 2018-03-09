using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyResearchAddin.Presentation.Model;
using PropertyResearchAddin.Service;

namespace PropertyResearchAddin.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private decimal price = 0.00M;
        private string postcode;
        private string town;
        private IZooplaService zooplaService;
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
                    zooplaService.GetPrice(Postcode, Town);
                });
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