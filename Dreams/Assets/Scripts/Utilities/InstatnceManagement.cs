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
        int _MethodCount = GetMethodLength(typeof(ICreateInstance));

        for (int i = 0; i < _MethodCount; i++)
        {
            foreach (var instance in m_InstanceMonoBehavier)
            {
                if (instance != null && instance is ICreateInstance _I)
                {
                    m_createInstances.Add(_I);
                    _I.CallInit();
                }
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
