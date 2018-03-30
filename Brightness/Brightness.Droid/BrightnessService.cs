using Android.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace Brightness.Droid
{
    public sealed class BrightnessService : BaseBrightnessService
    {
        internal static void Initialize()
        {
            Mvx.RegisterSingleton<IBrightnessService>(new BrightnessService());
        }

        public override float GetBrightness()
        {
            var window = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity.Window;
            return window.Attributes.ScreenBrightness;
        }

        protected override void NativeSet(float brightness)
        {
            var window = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity.Window;
            var attributesWindow = new WindowManagerLayoutParams();
            attributesWindow.CopyFrom(window.Attributes);
            attributesWindow.ScreenBrightness = brightness;
            window.Attributes = attributesWindow;
        }
    }
}