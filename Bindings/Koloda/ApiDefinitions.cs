using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Xamarin.Bindings.Koloda
{
    // @interface DraggableCardView : UIView <UIGestureRecognizerDelegate>
    [BaseType(typeof(UIView))]
    [DisableDefaultCtor]
    interface DraggableCardView : IUIGestureRecognizerDelegate
    {
        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        DraggableCardView New();

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
        [Export("initWithCoder:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSCoder aDecoder);

        // @property (nonatomic) CGRect frame;
        [Export("frame", ArgumentSemantic.Assign)]
        CGRect Frame { get; set; }

        // -(BOOL)gestureRecognizer:(UIGestureRecognizer * _Nonnull)gestureRecognizer shouldReceiveTouch:(UITouch * _Nonnull)touch __attribute__((warn_unused_result));
        [Export("gestureRecognizer:shouldReceiveTouch:")]
        bool GestureRecognizer(UIGestureRecognizer gestureRecognizer, UITouch touch);
    }

    // @interface KolodaView : UIView
    [BaseType(typeof(UIView))]
    interface KolodaView
    {
        // @property (nonatomic) NSInteger countOfVisibleCards;
        [Export("countOfVisibleCards")]
        nint CountOfVisibleCards { get; set; }

        // @property (nonatomic) BOOL isLoop;
        [Export("isLoop")]
        bool IsLoop { get; set; }

        // @property (readonly, nonatomic) NSInteger currentCardIndex;
        [Export("currentCardIndex")]
        nint CurrentCardIndex { get; }

        // @property (readonly, nonatomic) NSInteger countOfCards;
        [Export("countOfCards")]
        nint CountOfCards { get; }

        // @property (nonatomic, weak) id<KolodaViewDataSource> _Nullable dataSource;
        [NullAllowed, Export("dataSource", ArgumentSemantic.Weak)]
        KolodaViewDataSource DataSource { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        KolodaViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<KolodaViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) BOOL isAnimating;
        [Export("isAnimating")]
        bool IsAnimating { get; }

        // @property (readonly, nonatomic) BOOL isRunOutOfCards;
        [Export("isRunOutOfCards")]
        bool IsRunOutOfCards { get; }

        // -(void)layoutSubviews;
        [Export("layoutSubviews")]
        void LayoutSubviews();

        // -(CGRect)frameForCardAt:(NSInteger)index __attribute__((warn_unused_result));
        [Export("frameForCardAt:")]
        CGRect FrameForCardAt(nint index);

        // -(void)applyAppearAnimationIfNeeded;
        [Export("applyAppearAnimationIfNeeded")]
        void ApplyAppearAnimationIfNeeded();

        // -(void)revertActionWithDirection:(enum SwipeResultDirection)direction;
        [Export("revertActionWithDirection:")]
        void RevertActionWithDirection(SwipeResultDirection direction);

        // -(void)reloadData;
        [Export("reloadData")]
        void ReloadData();

        // -(void)swipe:(enum SwipeResultDirection)direction force:(BOOL)force;
        [Export("swipe:force:")]
        void Swipe(SwipeResultDirection direction, bool force);

        // -(void)resetCurrentCardIndex;
        [Export("resetCurrentCardIndex")]
        void ResetCurrentCardIndex();

        // -(UIView * _Nullable)viewForCardAt:(NSInteger)index __attribute__((warn_unused_result));
        [Export("viewForCardAt:")]
        [return: NullAllowed]
        UIView ViewForCardAt(nint index);

        // -(BOOL)pointInside:(CGPoint)point withEvent:(UIEvent * _Nullable)event __attribute__((warn_unused_result));
        [Export("pointInside:withEvent:")]
        bool PointInside(CGPoint point, [NullAllowed] UIEvent @event);

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
        [Export("initWithCoder:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSCoder aDecoder);
    }

    // @protocol KolodaViewDataSource
    [Protocol, Model]
    interface KolodaViewDataSource
    {
        // @required -(NSInteger)kolodaNumberOfCards:(KolodaView * _Nonnull)koloda __attribute__((warn_unused_result));
        [Abstract]
        [Export("kolodaNumberOfCards:")]
        nint KolodaNumberOfCards(KolodaView koloda);

        // @required -(enum DragSpeed)kolodaSpeedThatCardShouldDrag:(KolodaView * _Nonnull)koloda __attribute__((warn_unused_result));
        [Abstract]
        [Export("kolodaSpeedThatCardShouldDrag:")]
        DragSpeed KolodaSpeedThatCardShouldDrag(KolodaView koloda);

        // @required -(UIView * _Nonnull)koloda:(KolodaView * _Nonnull)koloda viewForCardAt:(NSInteger)index __attribute__((warn_unused_result));
        [Abstract]
        [Export("koloda:viewForCardAt:")]
        UIView ViewForCardAt(KolodaView koloda, nint index);

        // @required -(OverlayView * _Nullable)koloda:(KolodaView * _Nonnull)koloda viewForCardOverlayAt:(NSInteger)index __attribute__((warn_unused_result));
        [Abstract]
        [Export("koloda:viewForCardOverlayAt:")]
        [return: NullAllowed]
        OverlayView ViewForCardOverlayAt(KolodaView koloda, nint index);
    }

    // @protocol KolodaViewDelegate
    [Protocol, Model]
    interface KolodaViewDelegate
    {
        // @required -(NSArray * _Nonnull)koloda:(KolodaView * _Nonnull)koloda allowedDirectionsForIndex:(NSInteger)index __attribute__((warn_unused_result));
        [Abstract]
        [Export("koloda:allowedDirectionsForIndex:")]
       // [Verify(StronglyTypedNSArray)]
        NSObject[] Koloda(KolodaView koloda, nint index);

        // @required -(BOOL)koloda:(KolodaView * _Nonnull)koloda shouldSwipeCardAt:(NSInteger)index in:(enum SwipeResultDirection)direction __attribute__((warn_unused_result));
        [Abstract]
        [Export("koloda:shouldSwipeCardAt:in:")]
        bool ShouldSwipeCardAt(KolodaView koloda, nint index, SwipeResultDirection direction);

        // @required -(void)koloda:(KolodaView * _Nonnull)koloda didSwipeCardAt:(NSInteger)index in:(enum SwipeResultDirection)direction;
        [Abstract]
        [Export("koloda:didSwipeCardAt:in:")]
        void DidSwipeCardAt(KolodaView koloda, nint index, SwipeResultDirection direction);

        // @required -(void)kolodaDidRunOutOfCards:(KolodaView * _Nonnull)koloda;
        [Abstract]
        [Export("kolodaDidRunOutOfCards:")]
        void KolodaDidRunOutOfCards(KolodaView koloda);

        // @required -(void)koloda:(KolodaView * _Nonnull)koloda didSelectCardAt:(NSInteger)index;
        [Abstract]
        [Export("koloda:didSelectCardAt:")]
        void DidSelectCardAt(KolodaView koloda, nint index);

        // @required -(BOOL)kolodaShouldApplyAppearAnimation:(KolodaView * _Nonnull)koloda __attribute__((warn_unused_result));
        [Abstract]
        [Export("kolodaShouldApplyAppearAnimation:")]
        bool KolodaShouldApplyAppearAnimation(KolodaView koloda);

        // @required -(BOOL)kolodaShouldMoveBackgroundCard:(KolodaView * _Nonnull)koloda __attribute__((warn_unused_result));
        [Abstract]
        [Export("kolodaShouldMoveBackgroundCard:")]
        bool KolodaShouldMoveBackgroundCard(KolodaView koloda);

        // @required -(BOOL)kolodaShouldTransparentizeNextCard:(KolodaView * _Nonnull)koloda __attribute__((warn_unused_result));
        [Abstract]
        [Export("kolodaShouldTransparentizeNextCard:")]
        bool KolodaShouldTransparentizeNextCard(KolodaView koloda);

        // @required -(void)koloda:(KolodaView * _Nonnull)koloda draggedCardWithPercentage:(CGFloat)finishPercentage in:(enum SwipeResultDirection)direction;
        [Abstract]
        [Export("koloda:draggedCardWithPercentage:in:")]
        void DraggedCardWithPercentage(KolodaView koloda, nfloat finishPercentage, SwipeResultDirection direction);

        // @required -(void)kolodaDidResetCard:(KolodaView * _Nonnull)koloda;
        [Abstract]
        [Export("kolodaDidResetCard:")]
        void KolodaDidResetCard(KolodaView koloda);

        // @required -(CGFloat)kolodaSwipeThresholdRatioMargin:(KolodaView * _Nonnull)koloda __attribute__((warn_unused_result));
        [Abstract]
        [Export("kolodaSwipeThresholdRatioMargin:")]
        nfloat KolodaSwipeThresholdRatioMargin(KolodaView koloda);

        // @required -(void)koloda:(KolodaView * _Nonnull)koloda didShowCardAt:(NSInteger)index;
        [Abstract]
        [Export("koloda:didShowCardAt:")]
        void DidShowCardAt(KolodaView koloda, nint index);

        // @required -(BOOL)koloda:(KolodaView * _Nonnull)koloda shouldDragCardAt:(NSInteger)index __attribute__((warn_unused_result));
        [Abstract]
        [Export("koloda:shouldDragCardAt:")]
        bool ShouldDragCardAt(KolodaView koloda, nint index);

        // @required -(void)kolodaPanBegan:(KolodaView * _Nonnull)koloda card:(DraggableCardView * _Nonnull)card;
        [Abstract]
        [Export("kolodaPanBegan:card:")]
        void KolodaPanBegan(KolodaView koloda, DraggableCardView card);

        // @required -(void)kolodaPanFinished:(KolodaView * _Nonnull)koloda card:(DraggableCardView * _Nonnull)card;
        [Abstract]
        [Export("kolodaPanFinished:card:")]
        void KolodaPanFinished(KolodaView koloda, DraggableCardView card);
    }

    // @interface OverlayView : UIView
    [BaseType(typeof(UIView))]
    interface OverlayView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
        [Export("initWithCoder:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSCoder aDecoder);
    }
}
