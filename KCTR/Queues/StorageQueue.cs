using System.Collections.Generic;

namespace KCTR
{
    public class StorageQueue : List<IBuildable>, IConfigNode
    {
        public string Name { get; set; }


        public void Load(ConfigNode node)
        {
            
        }

        public void Save(ConfigNode node)
        {

        }
    }
}
