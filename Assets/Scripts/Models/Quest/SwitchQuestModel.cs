using UnityEngine;

namespace My2DPlatformer.Quest
{
    public class SwitchQuestModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.GetComponent<CharacterView>();
        }

    }
}