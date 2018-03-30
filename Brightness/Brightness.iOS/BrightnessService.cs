using MvvmCross.Platform;
using UIKit;

namespace Brightness.iOS
{
    public class BrightnessService : BaseBrightnessService
    {
        internal static void Initialize()
        {
            Mvx.RegisterSingleton<IBrightnessService>(new BrightnessService());
        }

        public override float GetBrightness()
        {
            return (float)UIScreen.MainScreen.Brightness;
        }

        protected override void NativeSet(float brightness)
        {
            UIScreen.MainScreen.Brightness = brightness;
        }
    }
}