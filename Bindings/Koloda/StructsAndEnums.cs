using System;
using ObjCRuntime;

namespace Xamarin.Bindings.Koloda
{
    [Native]
    public enum DragSpeed : long
    {
        Slow = 0,
        Moderate = 1,
        Default = 2,
        Fast = 3
    }

    [Native]
    public enum SwipeResultDirection : long
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3,
        TopLeft = 4,
        TopRight = 5,
        BottomLeft = 6,
        BottomRight = 7
    }
}
