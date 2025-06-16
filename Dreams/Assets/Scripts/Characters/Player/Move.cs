using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour, IState
{
    [field: SerializeField] public InputActionReference inputState { get; set; }
    [field: SerializeField] public EAnimationState animationState { get; set; }

    Vector2 m_MoveAcess;
    [SerializeField] float m_PlayerSpeed;
    [SerializeField] ControlleCharacter m_ControlleCharacterScript;
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
            m_ControlleCharacterScript.MoveCharacter(m_MoveAcess.x, 0, m_MoveAcess.y, m_PlayerSpeed);
            await Task.Yield();
        }
    }

}
