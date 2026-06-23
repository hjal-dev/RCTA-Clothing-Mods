using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Mod;
using System.Reflection;

namespace RCTA.AdaWong;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.rcta.adawong";
    public override string Name { get; init; } = "RCTA - Ada Wong [RE4R]";
    public override string Author { get; init; } = "TRAPPUSSY, Hj";
    public override List<string>? Contributors { get; init; }
    public override SemanticVersioning.Version Version { get; init; } = new("1.0.2");
    public override SemanticVersioning.Range SptVersion { get; init; } = new("~4.0.0");
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, SemanticVersioning.Range> ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", SemanticVersioning.Range.Parse("~2.0.0") }
    };
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; } = true;
    public override string License { get; init; } = "NCSA";
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 2)]
public class AdaWongMod(WTTServerCommonLib.WTTServerCommonLib wtt) : IOnLoad
{
    public async Task OnLoad()
    {
        var assembly = Assembly.GetExecutingAssembly();

        await wtt.CustomClothingService.CreateCustomClothing(assembly);
        await wtt.CustomHeadService.CreateCustomHeads(assembly);
    }
}
