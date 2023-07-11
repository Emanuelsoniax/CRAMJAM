
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public enum Fairies {
    Green,
    Blue,
    Red
}

public class Fairy : MonoBehaviour {

    [Header("Settings")]
    [ReadOnly, SerializeField]
    private Color fairyColor;
    private MaterialPropertyBlock propertyBlock;
    [SerializeField]
    private Fairies fairyType;
    [SerializeField]
    private FairyColors colors;
    [SerializeField]
    private Light2D fairyLight;

    private void Awake() {
        switch (fairyType) {
            case Fairies.Green: {
                fairyColor = colors.fairyColors[0];
                return;
            }
            case Fairies.Blue: {
                fairyColor = colors.fairyColors[1];
                return;
            }
            case Fairies.Red: {
                fairyColor = colors.fairyColors[2];
                return;
            }
        }
    }

    private void Start() {
        propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", fairyColor);
        GetComponent<SpriteRenderer>().SetPropertyBlock(propertyBlock);
        fairyLight.color = fairyColor;
    }

    private void Update() {
        
    }

}
