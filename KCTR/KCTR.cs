
namespace KCTR
{
    [KSPScenario(ScenarioCreationOptions.AddToAllGames, GameScenes.EDITOR, GameScenes.FLIGHT, GameScenes.SPACECENTER, GameScenes.TRACKSTATION)] //TODO: determine if we need to add to mainmenu
    public class KCTR : ScenarioModule
    {
        public void Start()
        {
            Logging.LogInfo("Startup! Hello, World!");
        }
    }
}
