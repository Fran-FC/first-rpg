using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpawnPoint playerSpawnpoint;
    public SpawnPoint enemySpawnpoint;
    public static GameManager instance = null;
    private void Awake() {
        if(instance!= null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }

    private void Start() {
        SetupScene();
    }

    private void SetupScene() {
        SpawnPlayer();

        SpawnEnemy();
    }
    private void SpawnPlayer () {
        if (playerSpawnpoint != null){
            GameObject player = playerSpawnpoint.SpawnObject();

            CameraManager.instance.virtualCamera.Follow = player.transform;
        }

        return;
    }
    private void SpawnEnemy () {
        if(enemySpawnpoint != null) {
            GameObject enemy = enemySpawnpoint.SpawnObject();
        }
    }
}
