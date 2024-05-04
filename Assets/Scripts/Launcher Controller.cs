using System.Collections;
using UnityEngine;


public class LauncherController : MonoBehaviour
{
    // Public Variables
    public Collider ball;
    public KeyCode input;
    public float maxTimeHold;
    public float maxForce;

    // Private Variables
    private bool isHold;

    private void Start()
    {
        isHold = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == ball)
        {
            ReadInput(ball);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
    }
}