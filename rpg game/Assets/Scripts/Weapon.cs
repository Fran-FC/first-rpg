using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject ammoPrefab;
    static List<GameObject> ammoPool;
    public int poolSize;
    public float weaponVelocity;
    [HideInInspector]
    public Animator animator;
    Camera localCamera;
    bool shooting = false;

    enum Quadrant
    {
        East, South, West, North
    }

    private void Start() {
        animator = GetComponent<Animator>();
        shooting = false;
        localCamera = Camera.main;
    }
    void Awake() {
        if (ammoPool == null) {
            ammoPool = new List<GameObject>();
        }
        for (int i = 0; i < poolSize; i++) {
            GameObject ammoObject = Instantiate(ammoPrefab);
            ammoObject.SetActive(false);
            ammoPool.Add(ammoObject);
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            shooting = true;
            FireAmmo();
        } else {
            shooting = false;
        }
    }

    GameObject SpawnAmmo(Vector3 location) {
        foreach (GameObject ammo in ammoPool) {
            if (ammo.activeSelf == false) {
                ammo.SetActive(true);
                ammo.transform.position = location;
                return ammo;
            }
        }
        return null;
    }

    void FireAmmo() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject ammo = SpawnAmmo(transform.position);

        if (ammo != null)
        {
            Arc arcScript = ammo.GetComponent<Arc>();
            float travelDuration = 1.0f / weaponVelocity;
            StartCoroutine(arcScript.TravelArc(mousePosition, travelDuration));
        }
    }

    private void OnDestroy() {
        ammoPool = null;
    }
}
