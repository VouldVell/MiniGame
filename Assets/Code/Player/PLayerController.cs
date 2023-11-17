using System.Threading.Tasks;
using UnityEngine;

namespace Code.Player
{
    public class PLayerController : IOnController, IOnFixedUpdate
    {
        private readonly PlayerView _player;

        public PLayerController(PlayerView player)
        {
            _player = player;
        }

        private void Move(float fixedDeltaTime)
        {
            _player.Rigidbody.MovePosition(_player.Rigidbody.position + Vector3.right * 5f * fixedDeltaTime);
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (_player.isDead)
            {
                return;
            }
            else
            {
                _player.Animator.SetBool("IsJump", false);
                Move(fixedDeltaTime);

                if (_player.isGrounded)
                {
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began)
                        {
                            _player.Rigidbody.AddForce(Vector3.up*6, ForceMode.Impulse);
                            _player.Animator.SetBool("IsJump", true);
                            _player.isGrounded = false;
                        }
                    }
                }
                
            }
            

            
        }

        
    }
}