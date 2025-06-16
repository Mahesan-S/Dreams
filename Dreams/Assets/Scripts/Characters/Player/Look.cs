using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour, IState
{
    [field: SerializeField] public InputActionReference inputState { get; set; }
    [field: SerializeField] public EAnimationState animationState { get; set; }

    [SerializeField] Transform m_Cameraranfoem,PlayerTranform;
    Vector2 m_DelaAcess;
    [SerializeField] float m_sensitivity;
    [SerializeField] float m_XRotation;
    [SerializeField] float LookRange;

    public void inti()
    {

    }
    public void IEnable()
    {
        inputState.action.Enable();
        inputState.action.performed += MoveCharacter;
        inputState.action.canceled += MoveCharacter;
    }
    public void IDisable()
    {
        inputState.action.Disable();
        inputState.action.performed -= MoveCharacter;
        inputState.action.canceled -= MoveCharacter;
    }

    public void MoveCharacter(InputAction.CallbackContext _context)
    {
        m_DelaAcess = _context.ReadValue<Vector2>();
        m_XRotation -= m_DelaAcess.y;
        m_XRotation = Mathf.Clamp(m_XRotation, -LookRange, LookRange);
        m_Cameraranfoem.rotation = Quaternion.Euler(m_XRotation, 0, 0);

        PlayerTranform.Rotate(Vector3.up * m_DelaAcess.x);
    }
}
