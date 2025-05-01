using System.Collections;
using UnityEngine;

public class Karkios_AlwaysLookAtTarget : MonoBehaviour
{
    // Youtube: https://www.youtube.com/watch?v=2XEiHf1N_EY
    public Transform Target;
    public float Speed = 1f;

    private Coroutine LookCoroutine;

    // Update is called once per frame
    public void StartRotating()
    {
        if (LookCoroutine !=null)
        {
            StopCoroutine(LookCoroutine);
        }
        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);

        float time = 0;

            while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * Speed;

            yield return null;
        }
    }
}
