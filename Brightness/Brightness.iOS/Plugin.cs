using System;
using MvvmCross.Platform.Plugins;

namespace Brightness.iOS
{
    public class Plugin : IMvxPlugin
    {
        public void Load() => BrightnessService.Initialize();
    }
}