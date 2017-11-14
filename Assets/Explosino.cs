using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosino : MonoBehaviour
{

    public float radius = 500.0F;
    public float power = 1000.0F;
    void Start()
    {
        Invoke("Explode", 2);
    }

    public GameObject exlplosionGo;

    void Boom()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != false)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                Debug.Log("bum");
            }
        }
    }

    void Explode()
    {
        exlplosionGo.SetActive(true);
        Invoke("Boom", 0.1f);
        Destroy(gameObject,0.2f);

    }


}
