
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour {

    [Header("Components")]
    [SerializeField]
    private Light2D playerLight;
    [SerializeField]
    private FairyColors colors;

    [SerializeField]
    private Fairies currentFairy;
    [SerializeField, ReadOnly]
    private int chooseFairy;
    private Color color;

    private void Start() {
        chooseFairy = (int)currentFairy;
        SwitchFairies();
        GetComponent<SpriteRenderer>().material.SetColor("_Color", color);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q))                        //Switch naar het vorige karakter
      {
            if (chooseFairy == 0) {
                chooseFairy = 2;
            }
            else {
                chooseFairy -= 1;
            }
            SwitchFairies();
        }

        if (Input.GetKeyDown(KeyCode.E))                        //Switch naar het voldende karakter
        {
            if (chooseFairy == 2) {
                chooseFairy = 0;
            }
            else {
                chooseFairy += 1;
            }
            SwitchFairies();
        }

        switch (currentFairy) {
            case Fairies.Green: {
                color = colors.fairyColors[0];
                return;
            }
            case Fairies.Blue: {
                color = colors.fairyColors[1];
                return;
            }
            case Fairies.Red: {
                color = colors.fairyColors[2];
                return;
            }
        }
    }

    private void SwitchFairies() {
        currentFairy = (Fairies)chooseFairy;
        playerLight.color = color;
        GetComponent<SpriteRenderer>().material.SetColor("_Color",color);
    }

}
