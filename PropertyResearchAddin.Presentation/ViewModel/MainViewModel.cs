using GalaSoft.MvvmLight;
using PropertyResearchAddin.Presentation.Model;

namespace PropertyResearchAddin.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private decimal price = 0.00M;

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                Set(ref price, value);
            }
        }

       
        public MainViewModel(IDataService dataService)
        {
            
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}