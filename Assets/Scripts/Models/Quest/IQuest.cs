using System;

namespace My2DPlatformer.Quest
{
    public interface IQuest
    {
        event Action<IQuest> Completed;
        bool IsCompleted { get; }
        void Reset();
    }
}