using UnityEngine;

namespace My2DPlatformer.Quest
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}