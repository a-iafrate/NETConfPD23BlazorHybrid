using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if ANDROID
using Android.Content;
using Android.Views;
using Android.Runtime;
#elif IOS
using UIKit;
#endif

namespace NETConfPD23BlazorHybrid.Helpers
{
    public enum DeviceOrientation
    {
        Undefined,
        Landscape,
        Portrait
    }

    public class DeviceOrientationService
    {
        public DeviceOrientation GetOrientation()
        {
#if ANDROID
            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            SurfaceOrientation orientation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = orientation == SurfaceOrientation.Rotation90 || orientation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientation.Landscape : DeviceOrientation.Portrait;
#elif IOS
            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = orientation == UIInterfaceOrientation.Portrait || orientation == UIInterfaceOrientation.PortraitUpsideDown;
            return isPortrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;
#else
            var orientation=DeviceDisplay.Current.MainDisplayInfo.Orientation;
            return orientation==DisplayOrientation.Landscape?DeviceOrientation.Landscape:DeviceOrientation.Portrait;

#endif
        }
    }
}
