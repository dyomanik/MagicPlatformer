using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My2DPlatformer.Quest
{
    [CreateAssetMenu(menuName = "Configs/Quest/QuestItemsConfig", fileName = "QuestItemsConfig", order = 0)]
    public class QuestItemsConfig : ScriptableObject
    {
        public int questId;
        public List<int> questItemIdCollection;
    }
}