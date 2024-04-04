using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "data", menuName = "Scriptables/Data",order = 1)]
public class StoreData : ScriptableObject
{
    [Range(0,100)]
    public int bulletCount;
    
    public int count;
    public Vector3 lastPosition;
    public float score;
}
