using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour, IState
{
    [field: SerializeField] public InputActionReference inputState { get; set; }
    Vector2 m_MoveAcess;
    [SerializeField] float m_PlayerSpeed;

    public void inti()
    {

    }
    public void IEnable()
    {
        inputState.action.Enable();
        inputState.action.started += MoveCharacter;
        inputState.action.canceled += MoveCharacter;
    }
    public void IDisable()
    {
        inputState.action.Disable();
        inputState.action.started -= MoveCharacter;
        inputState.action.canceled -= MoveCharacter;
    }

    public async void MoveCharacter(InputAction.CallbackContext _context)
    {
        m_MoveAcess = _context.ReadValue<Vector2>();
        while (m_MoveAcess.x != 0 || m_MoveAcess.y != 0)
        {
            await Task.Yield();
        }
    }

}
