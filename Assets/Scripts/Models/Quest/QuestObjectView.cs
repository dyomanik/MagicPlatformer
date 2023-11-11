using System;
using UnityEngine;

namespace My2DPlatformer.Quest
{
    public class QuestObjectView : MonoBehaviour
    {
        [SerializeField]
        private Color _completedColor;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private int _id;

        private Color _defaultColor;

        public int Id => _id;

        public Action<CharacterView> OnLevelObjectContact;
        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        public void ProcessComplete()
        {
            _spriteRenderer.color = _completedColor;
        }

        public void ProcessActivate()
        {
            _spriteRenderer.color = _defaultColor;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var levelObject = collider.GetComponent<CharacterView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}