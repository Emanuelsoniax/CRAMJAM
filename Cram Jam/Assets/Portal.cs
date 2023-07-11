
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public delegate void PortalReached();
    public static event PortalReached OnPortalReached;


    private void OnTriggerEnter2D(Collider2D collision) {
       if (collision.TryGetComponent(out PlayerManager player)) {
            OnPortalReached();
       }
    }

}
