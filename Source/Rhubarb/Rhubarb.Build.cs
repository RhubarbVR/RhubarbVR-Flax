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

        // Here you can modify the build options for your game module
        // To reference another module use: options.PublicDependencies.Add("Audio");
        // To add C++ define use: options.PublicDefinitions.Add("COMPILE_WITH_FLAX");
        // To learn more see scripting documentation.
    }
}
