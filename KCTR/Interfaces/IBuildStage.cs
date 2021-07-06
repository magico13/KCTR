namespace KCTR
{
    public interface IBuildStage : IConfigNode
    {
        string Name { get; set; }
        float Complexity { get; set; }
        float Progress { get; set; }
        bool Completed { get; set; }

        float Update(float progress);
    }
}
