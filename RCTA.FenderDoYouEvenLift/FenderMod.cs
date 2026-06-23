using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Mod;
using System.Reflection;

namespace RCTA.FenderDoYouEvenLift;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.rcta.fender";
    public override string Name { get; init; } = "RCTA - Fender Do You Even Lift [CODMW3]";
    public override string Author { get; init; } = "TRAPPUSSY, Hj";
    public override List<string>? Contributors { get; init; }
    public override SemanticVersioning.Version Version { get; init; } = new("1.0.3");
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
public class FenderMod(WTTServerCommonLib.WTTServerCommonLib wtt) : IOnLoad
{
    public async Task OnLoad()
    {
        var assembly = Assembly.GetExecutingAssembly();

        await wtt.CustomClothingService.CreateCustomClothing(assembly);
        await wtt.CustomHeadService.CreateCustomHeads(assembly);
    }
}
