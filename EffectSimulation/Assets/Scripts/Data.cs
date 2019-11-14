using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [SerializeField] private List<DataBool> bools = new List<DataBool>();
    [SerializeField] private List<DataInt> ints = new List<DataInt>();
    [SerializeField] private List<DataFloat> floats = new List<DataFloat>();
    [SerializeField] private List<DataVector2> vector2s = new List<DataVector2>();
    [SerializeField] private List<DataVector3> vector3s = new List<DataVector3>();
    [SerializeField] private List<DataGameObject> gameObjects = new List<DataGameObject>();


    public DataBool Bool(DataBool node)
    {
        DataBool found = bools.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            bools.Add(node);
        return node;
    }
    public DataInt Int(DataInt node)
    {
        DataInt found = ints.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            ints.Add(node);
        return node;
    }
    public DataFloat Float(DataFloat node)
    {
        DataFloat found = floats.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            floats.Add(node);
        return node;
    }
    public DataVector2 Vector2(DataVector2 node)
    {
        DataVector2 found = vector2s.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            vector2s.Add(node);
        return node;
    }

    public DataVector3 Vector3(DataVector3 node)
    {
        DataVector3 found = vector3s.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            vector3s.Add(node);
        return node;
    }

    public DataGameObject GameObject(DataGameObject node)
    {
        DataGameObject found = gameObjects.Find(d => d.Name == node.Name);
        if (found != null)
            return found;
        else
            gameObjects.Add(node);
        return node;
    } 

    public DataBool GetBool(string name) { return bools.Find(d => d.Name == name); }
    public DataInt GetInt(string name) { return ints.Find(d => d.Name == name); }
    public DataFloat GetFloat(string name) { return floats.Find(d => d.Name == name); }
    public DataVector2 GetVector2(string name) { return vector2s.Find(d => d.Name == name); }
    public DataVector3 GetVector3(string name) { return vector3s.Find(d => d.Name == name); }
    public DataGameObject GetDataGameObject(string name) { return gameObjects.Find(d => d.Name == name); }

    public bool Has(DataBool data) { return bools.Find(d => d.Name == data.Name) != null;  }
    public bool Has(DataInt data) { return ints.Find(d => d.Name == data.Name) != null; }
    public bool Has(DataFloat data) { return floats.Find(d => d.Name == data.Name) != null; }
    public bool Has(DataVector2 data) { return vector2s.Find(d => d.Name == data.Name) != null; }
    public bool Has(DataVector3 data) { return vector3s.Find(d => d.Name == data.Name) != null; }
    public bool Has(DataGameObject data) { return gameObjects.Find(d => d.Name == data.Name) != null; }

    public void Add(DataBool data) { bools.Add(data); }
    public void Add(DataInt data) { ints.Add(data); }
    public void Add(DataFloat data) { floats.Add(data); }
    public void Add(DataVector2 data) { vector2s.Add(data); }
    public void Add(DataVector3 data) { vector3s.Add(data); }
    public void Add(DataGameObject data) { gameObjects.Add(data); }
}
