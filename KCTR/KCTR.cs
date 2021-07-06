
namespace KCTR
{
    [KSPScenario(ScenarioCreationOptions.AddToAllGames, GameScenes.EDITOR, GameScenes.FLIGHT, GameScenes.SPACECENTER, GameScenes.TRACKSTATION)] //TODO: determine if we need to add to mainmenu
    public class KCTR : ScenarioModule
    {
        public static KCTR Instance { get; private set; }

        public KSC KSC { get; private set; } = new KSC(); // at some point this might end up being a list instead

        public BuildQueue TechQueue { get; private set; } = new BuildQueue();
        public BuildQueue KSCBuildingQueue { get; private set; } = new BuildQueue();
        public BuildQueue KSCRepairQueue { get; private set; } = new BuildQueue();

        public void Awake()
        {
            Instance = this;
        }

        public void Start()
        {
            Logging.LogInfo("Startup! Hello, World!");
        }

        public void Update()
        {

        }


        public override void OnLoad(ConfigNode node)
        {
            base.OnLoad(node);
        }

        public override void OnSave(ConfigNode node)
        {
            base.OnSave(node);
        }
    }
}
