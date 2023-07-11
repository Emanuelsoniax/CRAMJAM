
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour {

    [Header("Components")]
    [SerializeField]
    private Tiles tiles;
    [SerializeField]
    private PlayerManager player;

    private Sprite[] spritesToSwap = new Sprite[81];
    [SerializeField]
    private Tilemap[] tilemapsToSwap;
    [SerializeField]
    private GameObject[] tilemaps;

    private void Start() {
        PlayerManager.OnFairySwitched += UpdateTiles;
    }

    private void Update() {
        
    }

    private void UpdateTiles(Fairies _fairyType) {

        foreach (GameObject tilemap in tilemaps){
            tilemap.SetActive(false);
        }

        switch (_fairyType) {
            case Fairies.Green: {
                spritesToSwap = tiles.green;
                tilemaps[0].SetActive(true);
                break;
            }
            case Fairies.Blue: {
                spritesToSwap = tiles.blue;
                tilemaps[1].SetActive(true);
                break;
            }
            case Fairies.Red: {
                spritesToSwap = tiles.red;
                tilemaps[2].SetActive(true);
                break;
            }
        }

        for (int i = 0; i < tiles.tiles.Length; i++) {
            tiles.tiles[i].sprite = spritesToSwap[i];
        }

        foreach (Tilemap tilemap in tilemapsToSwap) {
            tilemap.RefreshAllTiles();
        }

    }
}
