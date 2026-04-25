using UnityEngine;

namespace TopDowown.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Move : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce; // tambah ini

        private Rigidbody2D body;
        protected Vector2 currentInput;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            body.linearVelocity = new Vector2(currentInput.x * moveSpeed, body.linearVelocity.y);
        }

        protected void Jump()
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }
}