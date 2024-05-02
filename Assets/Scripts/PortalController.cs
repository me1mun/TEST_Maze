using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private ParticleSystem portalFX;

    public bool isUnlocked {get; private set;}

    public void Activate()
    {
        isUnlocked = true;

        portalFX.gameObject.SetActive(true);
        portalFX.Play();
    }
}
