using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "resource", menuName = "Resource")]
public class Resources : ScriptableObject
{
    public int codename;
    public int category;

    public new string name;
    public Sprite sprite;
    public int amount;

}
