using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDog : MonoBehaviour
{
    [SerializeField] private Frightener frightener;
    [SerializeField] private SphereCollider rangeSphere;
    [SerializeField] private Animator animator;
   [SerializeField] private AudioSource audioSource;
    private bool isBarking = false;
    [SerializeField] private float barkInterval = 2;
    // Start is called before the first frame update
    void Start()
    {
        animator.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mothersPosition = Mother.instance.myTransform.position;
        if (!isBarking)
        {
            if (Vector3.Distance(transform.position, mothersPosition) < rangeSphere.radius)
            {
                isBarking = true;
                Bark();
            }
        }
        else
        {
            transform.LookAt(mothersPosition);
        }
    }

    private void Bark()
    {
        /*animator.Play("Bark");

        Invoke("Bark", barkInterval);*/
        animator.SetBool("IsBarking", true);
    }

    public void Frighten()
    {
        audioSource.Play();
        frightener.Frighten();

    }
}
