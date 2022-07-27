using System;
using UnityEngine;
namespace My2DPlatformer
{
    public class LevelObjectView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Collider2D _collider;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Transform Transform => _transform;
        public Collider2D Collider => _collider;
        public Rigidbody2D Rigidbody => _rigidbody;

    }
}