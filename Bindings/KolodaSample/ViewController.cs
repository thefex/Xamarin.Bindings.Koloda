using Foundation;
using Koloda;
using System;
using System.Linq;
using UIKit;
using Xamarin.Bindings.Koloda;

namespace KolodaSample
{
    public partial class ViewController : UIViewController, IKolodaViewDelegate, IKolodaViewDataSource
    {
        KolodaView kolodaView;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            kolodaView = new KolodaView(View.Frame);
            View.BackgroundColor = UIColor.Blue;
            View.Add(kolodaView);

            kolodaView.SetDataSource(this);
            kolodaView.SetDelegate(this);
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public NSArray GetAllowedDirectionsForIndex(KolodaView koloda, nint index)
        {
            NSNumber[] swipeResultDirections = (new long[]{
                (long)SwipeResultDirection.Left,
                (long)SwipeResultDirection.Right,
                (long)SwipeResultDirection.Up
            }).Select(x => new NSNumber(x)).ToArray();

            return NSArray.FromObjects(swipeResultDirections);
        }

        public bool ShouldSwipeCardAt(KolodaView koloda, nint index, SwipeResultDirection direction)
        {
            return true;
        }

        public void DidSwipeCardAt(KolodaView koloda, nint index, SwipeResultDirection direction)
        { 
        }

        public void KolodaDidRunOutOfCards(KolodaView koloda)
        {
            koloda.ReloadData();
        }

        public void DidSelectCardAt(KolodaView koloda, nint index)
        {
            System.Diagnostics.Debug.WriteLine(index);
        }

        public bool KolodaShouldApplyAppearAnimation(KolodaView koloda)
        {
            return true;
        }

        public bool KolodaShouldMoveBackgroundCard(KolodaView koloda)
        {
            return true;
        }

        public bool KolodaShouldTransparentizeNextCard(KolodaView koloda)
        {
            return true;
        }

        public void DraggedCardWithPercentage(KolodaView koloda, nfloat finishPercentage, SwipeResultDirection direction)
        {
            
        }

        public void KolodaDidResetCard(KolodaView koloda)
        {
             
        }

        public nfloat KolodaSwipeThresholdRatioMargin(KolodaView koloda)
        {
            return 0.5f;
        }

        public void DidShowCardAt(KolodaView koloda, nint index)
        { 
        }

        public bool ShouldDragCardAt(KolodaView koloda, nint index)
        {
            return true;
        }

        public void KolodaPanBegan(KolodaView koloda, DraggableCardView card)
        {

        }

        public void KolodaPanFinished(KolodaView koloda, DraggableCardView card)
        {

        }

        public nint KolodaNumberOfCards(KolodaView koloda)
        {
            return 5;
        }

        public DragSpeed KolodaSpeedThatCardShouldDrag(KolodaView koloda)
        {
            return DragSpeed.Default;
        }

        public UIView ViewForCardAt(KolodaView koloda, nint index)
        {
            return new UIImageView(UIImage.FromBundle("card_" + (index + 1)))
            {
                ContentMode = UIViewContentMode.Center
            };
        }

        public OverlayView ViewForCardOverlayAt(KolodaView koloda, nint index)
        {
            return new OverlayView();
        }
    }
}