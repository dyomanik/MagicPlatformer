using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace My2DPlatformer.Quest
{
    public class QuestsConfigurator : MonoBehaviour
    {
        [SerializeField]
        private QuestObjectView _singleQuestView;

        [SerializeField]
        private QuestStoryConfig[] _questStoryConfigs;

        [SerializeField]
        private QuestObjectView[] _questObjects;

        [Header("Interactive Objects")]
        [SerializeField]
        private GameObject _platform;

        private Quest _singleQuest;
        private List<IQuestStory> _questStories;

        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories =  new Dictionary<QuestType, Func<IQuestModel>> 
        { 
            { QuestType.Switch, () => new SwitchQuestModel() },
        };

        private Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories;

        private void Start()
        {
            _questStoryFactories = new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>
            { { QuestStoryType.Common, questCollection => new QuestStory(questCollection, _platform) },
              { QuestStoryType.Resettable, questCollection => new ResetableQuestStory(questCollection) },
            };

            _singleQuest = new Quest(_singleQuestView, new SwitchQuestModel());
            _singleQuest.Reset();

            _questStories = new List<IQuestStory>();
            foreach (var questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }
        }

        private void OnDestroy()
        {
            _singleQuest.Dispose();
            _questStories.Clear();
        }

        private IQuestStory CreateQuestStory(QuestStoryConfig config)
        {
            var quests = new List<IQuest>();
            foreach (var questConfig in config.quests)
            {
                var quest = CreateQuest(questConfig);
                if (quest == null)
                {
                    continue;
                }
                quests.Add(quest);
            }
            return _questStoryFactories[config.questStoryType].Invoke(quests);
        }
        private IQuest CreateQuest(QuestConfig config)
        {
            var questId = config.id;
            var questView = _questObjects.FirstOrDefault(value => value.Id == config.id);
            if (questView == null)
            {
                Debug.LogWarning($"QuestsConfigurator :: Start : Can't find view of quest{questId.ToString()}");
                return null;
            }
            if (_questFactories.TryGetValue(config.questType, out var factory))
            {
                var questModel = factory.Invoke();
                return new Quest(questView, questModel);
            }
            Debug.LogWarning($"QuestsConfigurator :: Start : Can't create model for quest{questId.ToString()}");
            return null;
        }
    }
}