using System.Collections.Generic;

namespace KCTR
{
    public class KSC : IConfigNode
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public BuildQueue VABQueue { get; set; }
        public BuildQueue SPHQueue { get; set; }

        public StorageQueue VABStorage { get; set; }
        public StorageQueue SPHStorage { get; set; }

        public List<BuildQueue> CustomQueues { get; set; }

        public void Load(ConfigNode node)
        {
            
        }

        public void Save(ConfigNode node)
        {
            
        }
    }
}
