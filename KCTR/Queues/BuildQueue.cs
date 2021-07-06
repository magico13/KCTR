using System.Collections.Generic;

namespace KCTR
{
    public class BuildQueue : StorageQueue
    {
        public List<float> Rates { get; set; } = new List<float>();
        
        public void UpdateItems(float dt)
        {
            for (int i = 0; i < Count; i++)
            {
                var rate = Rates[i];
                if (rate <= 0)
                {
                    break;
                }
                var item = this[i];
                if (item.CurrentStage != null)
                {
                    item.CurrentStage.Update(dt * rate);

                    // might want to pull this out of here
                    if (item.CurrentStage.Completed)
                    {
                        Logging.LogDebug($"Item {item.Name} ({item.Id}) - Stage {item.CurrentStage.Name} Complete");
                        item.CurrentStage = null;
                        foreach (var stage in item.Stages)
                        {
                            if (!stage.Completed)
                            {
                                Logging.LogDebug($"Item {item.Name} ({item.Id}) - New Stage {stage.Name}");
                                item.CurrentStage = stage;
                                break;
                            }
                        }
                        if (item.CurrentStage is null)
                        {
                            Logging.LogInfo($"Item {item.Name} ({item.Id}) - Complete");
                            item.Completed = true;
                            //pull it out of the queue, either into storage or activate it (for tech, buildings)
                        }
                    }
                }
            }
        }
    }
}
