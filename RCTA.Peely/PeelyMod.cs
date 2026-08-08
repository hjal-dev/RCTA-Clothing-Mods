using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Mod;
using System.Reflection;

namespace RCTA.Peely;

public record ModMetadata : IModMetadata
{
    public string ModGuid { get; init; } = "com.rcta.peely";
    public string Name { get; init; } = "RCTA - Peely Default [[FORTNITE]]";
    public string Author { get; init; } = "TRAPPUSSY, Hj";
    public List<string>? Contributors { get; init; }
    public SemanticVersioning.Version Version { get; init; } = new("1.0.4");
    public SemanticVersioning.Range SptVersion { get; init; } = new("~4.1.0");
    public List<string>? Incompatibilities { get; init; }
    public Dictionary<string, SemanticVersioning.Range> ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", SemanticVersioning.Range.Parse("~3.0.3") }
    };
    public string? Url { get; init; }
    public bool HasPrepatcher { get; init; } = false;
    public string License { get; init; } = "NCSA";
}

[Injectable(TypePriority = OnLoadOrder.Preload + 2)]
public class PeelyMod(WTTServerCommonLib.WTTServerCommonLib wtt) : IOnLoad
{
    public async Task OnLoadAsync(CancellationToken cancellationToken)
    {
        var assembly = Assembly.GetExecutingAssembly();

        await wtt.CustomClothingService.CreateCustomClothing(assembly);
        await wtt.CustomHeadService.CreateCustomHeads(assembly);
    }
}
