using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject bumperVFX;
    public GameObject switchVFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBumperVFX(Vector3 spawnPos)
    {
        GameObject.Instantiate(bumperVFX, spawnPos, Quaternion.identity);
    }

    public void PlaySwitchVFX(Vector3 spawnPos)
    {
        GameObject.Instantiate(switchVFX, spawnPos, Quaternion.identity);
    }
}

