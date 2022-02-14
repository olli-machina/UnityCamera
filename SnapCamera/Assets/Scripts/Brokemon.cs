using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Brokemon", menuName = "ScriptableObjects/Brokemon", order = 1)]
public class Brokemon : ScriptableObject
{
    public string broName;
    public MeshRenderer broModel;
    public int pointValue;
    public Vector3 broColor;
}
