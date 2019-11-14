using System;
using System.Collections.Generic;
using UnityEngine;

public class DataGameObject : DataNode
{
    [SerializeField] private GameObject value;
    public GameObject Value { get { return value; } set { this.value = value; } }
};
