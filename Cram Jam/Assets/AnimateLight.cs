
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnimateLight : MonoBehaviour {

    private Light2D light;

    private void Start() {
        light = GetComponent<Light2D>();
    }

    private void Update() {
        light.intensity = Mathf.Lerp(1.8f, 2.5f, Mathf.PingPong(Time.time, 1));
    }

}
