var target = Argument("target", "Default");
var targetProject = "./Brightness/Brightness.sln";
var nuspecFile = "./nuspec/Brightness.nuspec";
var apiKey = EnvironmentVariable("NUGET_API_KEY");

var packSettings = new NuGetPackSettings();
var buildSettings = new MSBuildSettings 
{
    Verbosity = Verbosity.Verbose,
    Configuration = "Release"
};

var publishSettings = new NuGetPushSettings 
{
    ApiKey = apiKey,
    Source = "https://www.nuget.org/api/v2/package", 
};

Task("Restore")
    .Does(() => NuGetRestore(targetProject));

Task("Build")
    .IsDependentOn("Restore")
    .Does(() => MSBuild(targetProject, buildSettings));

Task("Copy")
    .IsDependentOn("Build")
    .Does(() =>
    {
        //Setup
        EnsureDirectoryExists("build/lib/portable-net45+win+wpa81+wp80");
        EnsureDirectoryExists("build/lib/MonoAndroid10/Bootstrap");
        EnsureDirectoryExists("build/lib/Xamarin.iOS10/Bootstrap");
        EnsureDirectoryExists("build/content/MonoAndroid10/Bootstrap");
        EnsureDirectoryExists("build/content/Xamarin.iOS10/Bootstrap");

        //PCL
        CopyFiles(@"Brightness\Brightness\bin\Release\*.dll", @"build\lib\portable-net45+win+wpa81+wp80");

        //Android
        CopyFile(@"nuspec\BrightnessBootstrap.cs.pp", @"build\content\MonoAndroid10\Bootstrap\BrightnessBootstrap.cs.pp");
        CopyFiles(@"Brightness\Brightness.Droid\bin\Release\*.dll", @"build\lib\MonoAndroid10");

        //iOS
        CopyFile(@"nuspec\BrightnessBootstrapAction.cs.pp", @"build\content\Xamarin.iOS10\Bootstrap\BrightnessBootstrapAction.cs.pp");
        CopyFiles(@"Brightness\Brightness.iOS\bin\Release\*.dll", @"build\lib\Xamarin.iOS10");
    });

Task("Pack")
    .IsDependentOn("Copy")
    .Does(() => NuGetPack(nuspecFile, packSettings));

Task("Publish")
    .IsDependentOn("Pack")
    .Does(() => 
    {
        try
        {
            NuGetPush(GetFiles("*.nupkg").First().FullPath, publishSettings);
        }
        catch(CakeException) { /* Swallow exception if package already exists */}
    });

//Default Operation
Task("Default")
    .IsDependentOn("Publish");

RunTarget(target);