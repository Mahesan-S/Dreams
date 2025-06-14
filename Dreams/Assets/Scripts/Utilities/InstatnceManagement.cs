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
        CreateInstance(m_InstanceMonoBehavier);
        float _MethodLength = GetMethodLength(typeof(ICreateInstance));

        for (int i = 0; i < _MethodLength; i++)
        {
            for (int j = 0; i < m_createInstances.Count; j++)
            {
                string result = i switch
                {
                    //0 =>
                };
            }

        }

    }
    void CreateInstance(params object[] _Instance)
    {
        for (int i = 0; i < _Instance.Length; i++)
        {
            if (_Instance[i] is ICreateInstance _I)
                m_createInstances.Add(_I);
        }
    }

    int GetMethodLength(Type type)
    {
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public |
                                               BindingFlags.Instance);
        return methods.Length;
    }
}
