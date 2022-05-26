using System;
using Interaction;
using UnityEngine;
using Utilities;

namespace Player
{
    [RequireComponent(typeof(InteractionRaycast))]
    
    public class PlayerInteraction : Singleton<PlayerInteraction>
    {
        [SerializeField] private float requiredDistance;
        
        private IInteractive _interactiveObject;
        private InteractionRaycast _interactionRaycast;
        private Transform _selfTransform;

        public static Action<bool> OnInteractiveObject;

        private void Awake()
        {
            _interactionRaycast = GetComponent<InteractionRaycast>();
            _selfTransform = GetComponent<Transform>();
        }

        private void Update() => CheckInteractiveObject();

        private void CheckInteractiveObject()
        {
            var collider = _interactionRaycast.RaycastInCenter();
            _interactiveObject = IsInteractive(collider);
            OnInteractiveObject.Invoke(_interactiveObject != null);
        }

        private IInteractive IsInteractive(Collider collider)
        {
            if (collider == null) return null;
            if (collider.TryGetComponent(out IInteractive interactable) == false) return null;
            if (_selfTransform.position.DistanceIsLess(collider.transform.position, requiredDistance))
                return interactable;
            return null;
        }

        public void Interact() => _interactiveObject?.Interact();
    }
}

