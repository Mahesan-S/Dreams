using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICreateInstance
{

    public static Player s_Instance;

    [SerializeField] CharacterController m_CharacterController;
    public CharacterController GetPlayerCharacterController => m_CharacterController;

    public List<IState> m_StatesList;

    public void CallInit()
    {
        s_Instance = this;
    }

    public void GenerateInstance()
    {
        
    }
}
