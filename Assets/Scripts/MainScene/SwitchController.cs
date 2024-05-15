using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // Public Variables
    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;
    public float switchScore;

    //Private Variables
    private enum SwitchState
    {
        On,
        Off,
        Blinking
    }

    private Collider ball;
    private Renderer switchRenderer;
    private SwitchState state;

    [SerializeField]
    private Material offMaterial;
    [SerializeField]
    private Material onMaterial;
    [SerializeField]
    private float blinkTimer;
    [SerializeField]
    private int blinkNum;
    [SerializeField]
    private float blinkSpeed;

    // Start is called before the first frame update
    void Start()
    {
        switchRenderer = GetComponent<Renderer>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Collider>();
        SetSwitch(false);

        StartCoroutine(BlinkTimerStart(blinkTimer));
    }

    private IEnumerator BlinkTimerStart(float blinkTime)
    {
        yield return new WaitForSeconds(blinkTime);
        StartCoroutine(Blink(blinkNum, blinkSpeed));
    }

    private IEnumerator Blink(int blinkNum, float blinkSpeed)
    {
        state = SwitchState.Blinking;

        for (int i = 0; i < blinkNum; i++)
        {
            switchRenderer.material = onMaterial;
            yield return new WaitForSeconds(blinkSpeed);
            switchRenderer.material = offMaterial;
            yield return new WaitForSeconds(blinkSpeed);
        }

        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(blinkTimer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            Toggle();
            audioManager.PlaySwitchSFX(other.transform.position);
            vfxManager.PlaySwitchVFX(other.transform.position);
        }
    }

    private void SetSwitch(bool active)
    {
        if (active)
        {
            state = SwitchState.On;
            switchRenderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            switchRenderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(blinkTimer));
        }
    }

    private void Toggle()
    {
        scoreManager.AddScore(switchScore);
        if (state == SwitchState.On)
        {
            SetSwitch(false);
        }
        else
        {
            SetSwitch(true);
        }
    }
}
