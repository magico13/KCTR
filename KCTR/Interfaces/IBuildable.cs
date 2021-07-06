using System.Collections.Generic;

namespace KCTR
{
    public interface IBuildable : IConfigNode
    {
        string Id { get; set; }
        string Name { get; set; }
        bool Completed { get; set; }
        IBuildStage CurrentStage { get; set; }
        List<IBuildStage> Stages { get; set; }

        void Update(float progress);
    }
}
