
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FairyColors")]
public class FairyColors : ScriptableObject {

    [ColorUsage(true, true)]
    public Color[] fairyColors;
}
