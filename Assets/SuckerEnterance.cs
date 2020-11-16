using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckerEnterance : MonoBehaviour
{
    [SerializeField] private Transform exit;

    private void OnTriggerEnter(Collider other)
    {
        Baby baby = other.gameObject.GetComponentInParent<Baby>();
        if (baby != null)
        {
            baby.GetSucked();
            Invoke("SpawnFeathers", 0.2f);
        }
    }

    private void SpawnFeathers()
    {
        Transform effect = Spawner.instance.SpawnFeatherStream().transform;
        effect.position = exit.position;
    }
}
