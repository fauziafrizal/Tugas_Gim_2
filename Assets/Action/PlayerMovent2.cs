using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDowown.Movement
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : Move
    {
        private void OnMove(InputValue value)
        {
            Vector2 playerInput = value.Get<Vector2>();
            currentInput = playerInput;
        }
    }
}