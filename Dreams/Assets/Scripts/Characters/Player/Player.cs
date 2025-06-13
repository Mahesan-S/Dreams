using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICreateInstance
{

    public static Player s_Instance;

    public List<Object> m_IStateObjList;
    public List<IState> m_StatesList = new();

    private void Start()
    {
        CallInit();
        GenerateInstance();
    }

    public void CallInit()
    {
        s_Instance = this;
    }

    public void GenerateInstance()
    {
        foreach (var state in m_IStateObjList)
        {
            if (state is IState _State)
            {
                m_StatesList.Add(_State);
                _State.IEnable();
            }
        }
    }
}
