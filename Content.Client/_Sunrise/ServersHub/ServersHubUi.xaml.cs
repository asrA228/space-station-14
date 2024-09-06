using System.Linq;
using Content.Shared._Sunrise.ServersHub;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client._Sunrise.ServersHub;

[GenerateTypedNameReferences]
public sealed partial class ServersHubUi : DefaultWindow
{
    [Dependency] private readonly ServersHubManager _serversHubManager = default!;

    public ServersHubUi()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);

        _serversHubManager.ServersDataListChanged += RefreshServersHubHeader;
    }

    private void RefreshServersHubHeader(List<ServerHubEntry> servers)
    {
        var totalPlayers = _serversHubManager.ServersDataList.Sum(server => server.CurrentPlayers);
        var maxPlayers = _serversHubManager.ServersDataList.Sum(server => server.MaxPlayers);
        ServersHubHeaderLabel.Text = Loc.GetString("serverhub-playingnow", ("total", totalPlayers), ("max", maxPlayers));
    }
}
