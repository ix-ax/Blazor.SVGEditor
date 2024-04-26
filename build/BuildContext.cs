using System.IO;
using Cake.Common.Tools.DotNet.Test;
using Cake.Core;
using Cake.Frosting;

public class BuildContext : FrostingContext
{
    public bool Delay { get; set; }

    public BuildContext(ICakeContext context)
        : base(context)
    {

    }

    public string Artifacts => Path.Combine(Environment.WorkingDirectory.FullPath, "..//artifacts//");

    public string RootDir => Path.GetFullPath(Path.Combine(Environment.WorkingDirectory.FullPath, ".."));

    public string GitHubUser { get; } = System.Environment.GetEnvironmentVariable("GH_USER");

    public string GitHubToken { get; } = System.Environment.GetEnvironmentVariable("GH_TOKEN");

    public Cake.Common.Tools.DotNet.Build.DotNetBuildSettings DotNetBuildSettings { get; }

    public string ArtifactsNugets => EnsureFolder(Path.Combine(Artifacts, "nugets"));
    public DotNetTestSettings DotNetTestSettings { get; set; }

    public string EnsureFolder(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return path;
    }
}