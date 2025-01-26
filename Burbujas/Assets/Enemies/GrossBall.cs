using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrossBall : MonoBehaviour
{
    [SerializeField] private ParticleSystem soapPS;
    [SerializeField] private ParticleSystem boomPS;
    [SerializeField] private Material soapyGrossMaterial;

    private MeshRenderer meshRenderer;

    private bool isSoapy;

    private void Start()
    {
        isSoapy = false;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnParticleCollision(GameObject particle)
    {
        if (particle.CompareTag("Soap"))
        {
            SoapOn();
        }
        if (particle.CompareTag("Water") && isSoapy)
        {
            SoapOff();
        }
    }

    private void SoapOn()
    {
        meshRenderer.material = soapyGrossMaterial;
        isSoapy = true;
        soapPS.Play();
    }

    private void SoapOff()
    {
        GetComponentInParent<GrossyEnemy>().EliminateBall(this.gameObject);
    }
}
