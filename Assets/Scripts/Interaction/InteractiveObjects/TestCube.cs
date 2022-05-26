using UnityEngine;

namespace Interaction.InteractiveObjects
{
    public class TestCube : MonoBehaviour, IInteractive
    {
        public void Interact()
        {
            Debug.Log("A");
        }
    }
}