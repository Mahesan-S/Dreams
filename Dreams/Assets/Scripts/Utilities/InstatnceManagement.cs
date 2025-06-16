using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InstatnceManagement : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] m_InstanceMonoBehavier;

    List<ICreateInstance> m_createInstances = new List<ICreateInstance>();

    private void Awake()
    {
        AddInstance(m_InstanceMonoBehavier);
        float _MethodLength = GetMethodLength(typeof(ICreateInstance));

        for (int i = 0; i < _MethodLength; i++)
        {
            for (int j = 0; j < m_createInstances.Count; j++)
            {
                switch (i)
                {
                    case 0:
                        m_createInstances[j].GenerateInstance();
                        break;
                    case 1:
                        m_createInstances[j].CallInit();
                        break;
                }
            }

        }

    }
    void AddInstance(params object[] _Instance)
    {
        for (int i = 0; i < _Instance.Length; i++)
        {
            if (_Instance[i] is ICreateInstance _I)
            {
                m_createInstances.Add(_I);
            }
        }
    }

    int GetMethodLength(Type type)
    {
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public |
                                               BindingFlags.Instance);
        return methods.Length;
    }
}
