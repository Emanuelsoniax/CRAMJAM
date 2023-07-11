
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out PlayerManager player)) {
            SpawnPlayer(player);
        }
    }

    public void SpawnPlayer(PlayerManager _player) {
        _player.transform.position = this.transform.position;
    }

}
