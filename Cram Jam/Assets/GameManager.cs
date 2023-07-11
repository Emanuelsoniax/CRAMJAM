
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.Universal;

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
    [SerializeField]
    private Light2D colorLight;
    [SerializeField]
    private Light2D bgLight;

    private Fairies currentFairyType;

    private void Start() {
        PlayerManager.OnFairyChosen += UpdateTiles;
        PlayerManager.OnFairySwitched += ShowColor;
    }

    private void Update() {

        for (int i = 0; i < tilemaps.Length; i++) {
            if (i == (int)currentFairyType) {
                tilemaps[i].GetComponent<TilemapCollider2D>().enabled = true;
                tilemaps[i].SetActive(true);
                tilemaps[i].GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
            }
            else {
                tilemaps[i].GetComponent<TilemapCollider2D>().enabled = false;
            }
        
        }
    }

    private void ShowColor(Fairies _fairyType) {
        foreach (GameObject tilemap in tilemaps) {
            tilemap.SetActive(false);
        }

        switch (_fairyType) {
            case Fairies.Green: {
                tilemaps[0].SetActive(true);
                tilemaps[0].GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                break;
            }
            case Fairies.Blue: {
                tilemaps[1].SetActive(true);
                tilemaps[1].GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                break;
            }
            case Fairies.Red: {
                tilemaps[2].SetActive(true);
                tilemaps[2].GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                break;
            }
        }
    }

    private void UpdateTiles(Fairies _fairyType) {

        currentFairyType = _fairyType;

        foreach (GameObject tilemap in tilemaps){
            tilemap.SetActive(false);
        }

        switch (_fairyType) {
            case Fairies.Green: {
                spritesToSwap = tiles.green;
                tilemaps[0].SetActive(true);
                tilemaps[0].GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
                break;
            }
            case Fairies.Blue: {
                spritesToSwap = tiles.blue;
                tilemaps[1].SetActive(true);
                tilemaps[1].GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
                break;
            }
            case Fairies.Red: {
                spritesToSwap = tiles.red;
                tilemaps[2].SetActive(true);
                tilemaps[2].GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
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
