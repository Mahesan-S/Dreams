using UnityEngine;

public class ControlleCharacter : MonoBehaviour
{
    [SerializeField] CharacterController m_Controller;
    public CharacterController GetCcontroller => m_Controller;
    
    public void MoveCharacter(float x,float y,float z,float Speed)
    {
        m_Controller.Move(new Vector3(x,y,z) * Speed * Time.deltaTime );
    }
}
