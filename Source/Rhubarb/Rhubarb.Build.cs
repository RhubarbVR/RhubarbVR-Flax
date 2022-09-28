using Flax.Build;
using Flax.Build.NativeCpp;
using System;
using System.IO;

public class Rhubarb : GameModule
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

    }

    /// <inheritdoc />
    public override void Setup(BuildOptions options)
    {
        base.Setup(options);

        options.ScriptingAPI.IgnoreMissingDocumentationWarnings = true;
        var rhubarbEngine = Path.Combine(FolderPath, "..", "..", "RhubarbEngine");
        var files = Directory.GetFiles(rhubarbEngine);
        foreach (var item in files)
        {
            if (item.EndsWith(".dll"))
            {
                options.ScriptingAPI.FileReferences.Add(item);
            }
        }
        string runtimeName = null;
        switch (options.Platform.Target)
        {
            case TargetPlatform.Windows:
                switch (options.Architecture)
                {
                    case TargetArchitecture.x86:
                        runtimeName = "win-x86";
                        break;
                    case TargetArchitecture.x64:
                        runtimeName = "win-x64";
                        break;
                    default:
                        break;
                }
                break;
            case TargetPlatform.Linux:
                switch (options.Architecture)
                {
                    case TargetArchitecture.x64:
                        runtimeName = "linux-x64";
                        break;
                    case TargetArchitecture.ARM64:
                        runtimeName = "linux-arm64";
                        break;
                    default:
                        break;
                }
                break;
            case TargetPlatform.UWP:
                switch (options.Architecture)
                {
                    case TargetArchitecture.x64:
                        runtimeName = "win10-x64";
                        break;
                    default:
                        break;
                }
                break;
            case TargetPlatform.Android:

                break;
            case TargetPlatform.Mac:
                switch (options.Architecture)
                {
                    case TargetArchitecture.x64:
                        runtimeName = "osx-x64";
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }



        var nativeFiles = Path.Combine(rhubarbEngine, "runtimes", runtimeName, "native");
        var filese = Directory.GetFiles(nativeFiles);
        foreach (var item in filese)
        {
            options.DependencyFiles.Add(item);
        }

        // Here you can modify the build options for your game module
        // To reference another module use: options.PublicDependencies.Add("Audio");
        // To add C++ define use: options.PublicDefinitions.Add("COMPILE_WITH_FLAX");
        // To learn more see scripting documentation.
    }
}
