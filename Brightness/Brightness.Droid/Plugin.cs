using System;
using MvvmCross.Platform.Plugins;

namespace Brightness.Droid
{
    public class Plugin : IMvxConfigurablePlugin
    {
        public void Configure(IMvxPluginConfiguration configuration)
        {
        }

        public void Load() => BrightnessService.Initialize();
    }
}