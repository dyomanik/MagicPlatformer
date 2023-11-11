using UnityEngine;

namespace My2DPlatformer.Quest
{
    [CreateAssetMenu(menuName = "Configs/Quest/QuestConfig", fileName = "QuestConfig", order = 0)]
    public class QuestConfig : ScriptableObject
    {
        public int id;
        public QuestType questType;
    }

    public enum QuestType
    {
        Switch
    }
}