
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnimateLight : MonoBehaviour {

    private Light2D lightToAnimate;
    [SerializeField]
    private float start;
    [SerializeField]
    private float end;


    private void Start() {
        lightToAnimate = GetComponent<Light2D>();
    }

    private void Update() {
        lightToAnimate.intensity = Mathf.Lerp(start, end, Mathf.PingPong(Time.time, 1));
    }

}
