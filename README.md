# Mvx.Brightness [![Build Status](https://www.bitrise.io/app/fda20d566af19259/status.svg?token=xCOaEKBv9aMN0jVtkPBmiw&branch=master)](https://www.bitrise.io/app/fda20d566af19259)
MvvmCross Plugin to manipulate device brightness

# Usage

Resolve it:

``var brightnessService = Mvx.Resolve<IBrightnessService>();``

Use it at will:

```
// Sets the brightness. Parameter must be between 0 and 1 for iOS and between -1 and 1 for Android, or else this will throw. 
brightnessService.SetBrightness(0.2);

// Get brightness.
brightnessService.GetBrightness();
```

Check the Sample projects for a working example.
