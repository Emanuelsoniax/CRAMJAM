
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tiles")]
public class Tiles : ScriptableObject {

    public Tile[] tiles;
    public Sprite[] green;
    public Sprite[] blue;
    public Sprite[] red;
}
