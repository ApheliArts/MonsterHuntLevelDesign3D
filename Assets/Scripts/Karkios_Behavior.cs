using System.Collections;
using UnityEngine;

public class Karkios_Behavior : MonoBehaviour
{
    public GameObject Karkios;
    public GameObject Player;

    public float RotationAmount = 2f;
    public int TicksPerSecond = 60;
    public bool Pause = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Starts the game out with the Karkios in the ground.
        Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Flower");
    }
    void OnTriggerEnter(Collider other)
    {
        //When the player enters the trigger the Karkios will transfer to its Emerge animation and attack the player.
        Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Emerge", .5f);
    }
    // TESTING CODE DO NOT TOUCH
    public IEnumerator Rotate()
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / TicksPerSecond);

        while (true)
        {
            if(!Pause)
            {
                transform.Rotate(Vector3.up * RotationAmount);
            }

            yield return Wait;
        }
    }
}
