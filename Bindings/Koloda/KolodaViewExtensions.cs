using Foundation;
using Xamarin.Bindings.Koloda;

namespace Koloda
{
    public static class KolodaViewExtensions
    {
        public static void SetDataSource(this KolodaView kolodaView, IKolodaViewDataSource kolodaViewDataSource)
        {
            kolodaView.DataSource = kolodaViewDataSource as NSObject;
        }

        public static void SetDelegate(this KolodaView kolodaView, IKolodaViewDelegate kolodaViewDelegate)
        {
            kolodaView.WeakDelegate = kolodaViewDelegate as NSObject;
        }
    }
}
