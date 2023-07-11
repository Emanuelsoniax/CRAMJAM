
using System;
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
    private GameObject[] fairies;

    [SerializeField]
    public Fairies currentFairy;
    [SerializeField, ReadOnly]
    private int chooseFairy=0;
    private Color color;

    public delegate void SwitchedFairy(Fairies _currentFairy);
    public static event SwitchedFairy OnFairySwitched;

    public delegate void ChooseFairy(Fairies _currentFairy);
    public static event ChooseFairy OnFairyChosen;

    private void Start() {
        SwitchFairies();
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


        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }

    }

    private void Attack() {
        GetComponent<Animator>().SetTrigger("Attack");
        OnFairyChosen(currentFairy);
    }

    private void SwitchFairies() {
        currentFairy = (Fairies)chooseFairy;
        OnFairySwitched(currentFairy);


        foreach (GameObject fairy in fairies) {
            fairy.SetActive(true);
        }

        switch (currentFairy) {
            case Fairies.Green: {
                color = colors.fairyColors[0];
                fairies[0].SetActive(false);
                UpdateColors();
                return;
            }
            case Fairies.Blue: {
                color = colors.fairyColors[1];
                fairies[1].SetActive(false);
                UpdateColors();
                return;
            }
            case Fairies.Red: {
                color = colors.fairyColors[2];
                fairies[2].SetActive(false);
                UpdateColors();
                return;
            }
        }
    }

    private void UpdateColors() {
        playerLight.color = color;
        GetComponent<SpriteRenderer>().material.SetColor("_Color", color);
    }

}
