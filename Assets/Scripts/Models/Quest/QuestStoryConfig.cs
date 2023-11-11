using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My2DPlatformer.Quest
{
    [CreateAssetMenu(menuName = "Configs/Quest/QuestStoryConfig", fileName = "QuestStoryConfig", order = 0)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType questStoryType;
    }
    public enum QuestStoryType
    {
        Common,
        Resettable
    }
}