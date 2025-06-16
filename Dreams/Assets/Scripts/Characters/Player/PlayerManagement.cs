using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour, ICreateInstance
{

    public static PlayerManagement s_Instance;

    public List<Object> m_IStateObjList;
    public List<IState> m_StatesList = new();

    public void GenerateInstance()
    {
        s_Instance = this;
    }

    public void CallInit()
    {
        foreach (var state in m_IStateObjList)
        {
            if (state is IState _State)
            {
                m_StatesList.Add(_State);
                _State.inti();
                _State.IEnable();
            }
        }
       
    }
}
