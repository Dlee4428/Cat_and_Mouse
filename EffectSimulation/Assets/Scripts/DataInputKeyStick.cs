using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DataInputKeyStick : DataInput
{
    [SerializeField] private string name;
    public string Name { get { return name; } set { name = value; } }
    [SerializeField] private KeyCode positiveX;
    [SerializeField] private KeyCode negativeX;
    [SerializeField] private KeyCode positiveY;
    [SerializeField] private KeyCode negativeY;
    [Header("Data")]
    [SerializeField] private DataVector2 dataNode;
    [Header("Events")]
    [SerializeField] private UnityEvent onInputStart;
    [SerializeField] private UnityEvent onInput;
    [SerializeField] private UnityEvent onInputStop;

    public override void Start(Data data)
    {
        if (data.Has(dataNode))
            dataNode = data.GetVector2(dataNode.Name);
        else
            data.Add(dataNode);
    }

    public override void Update()
    {
        Vector2 input = Vector2.zero;

        if (Input.GetKey(positiveX))
            input.x += 1;
        if (Input.GetKey(negativeX))
            input.x -= 1;
        if (Input.GetKey(positiveY))
            input.y += 1;
        if (Input.GetKey(negativeY))
            input.y -= 1;

        float inputMag = input.sqrMagnitude;
        float dataMag = dataNode.Value.sqrMagnitude;

        if (inputMag != 0 && dataMag == 0)
            onInputStart.Invoke();
        if (inputMag != 0 && dataMag != 0)
            onInput.Invoke();
        if (inputMag == 0 && dataMag != 0)
            onInputStop.Invoke();

        if (inputMag > 0)
            input.Normalize();

        dataNode.Value = input;
    }
}
