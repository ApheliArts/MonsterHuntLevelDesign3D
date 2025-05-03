using System.Collections;
using UnityEngine;

public class Karkios_Behavior : MonoBehaviour
{
    public GameObject Karkios;
    public GameObject Player;

    public Transform Target;
    //Attacks
    public Transform Front;
    public Transform Left;
    public Transform Right;
    public Transform Back;
    //Layer to check for Player
    public LayerMask PlayerMask;

    public float Speed = 1f;

    public bool Rotate;
    public bool Move;

    public bool isAttacking;
    public bool Idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Starts the game out with the Karkios in the ground.
        Rotate = false;
        Move = false;

        isAttacking = false;
        Idle = true;

        gameObject.SetActive(true);

        Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Flower");
        Karkios.transform.LookAt(Player.transform.position);
    }

    //Rotation Script :)
    void Update()
    {
        if (Rotate == true)
        {
            //Get rotation location from Player
            Quaternion lookRotation = Quaternion.LookRotation(Target.position - Player.transform.position);

            //Makes the monster gradually turn towards player
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * Speed);

            //Movement Script
            if (Move == true)
            {
                Karkios.transform.position = Vector3.MoveTowards(Karkios.transform.position, Player.transform.position, Speed * .5f);
            }
        }
        //Karkios Fight Mechanics
        //Check for player "Looking"
        //If in certain area then it does certain attacks
        //if (!Move && !isAttacking && !Idle)
        //{
            //Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Jump");
            //Move = true;
            //Rotate = true;

            //Invoke(nameof(StopGettingRotatedIdiot), 5f);
        //}
        if (Physics.CheckSphere(Front.position, 5, PlayerMask) && !isAttacking)
        {
            Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Swipe");
        }
         else if (Physics.CheckSphere(Left.position, 5, PlayerMask) && !isAttacking)
        {
            Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Jump");
        }
        else if (Physics.CheckSphere(Right.position, 5, PlayerMask) && !isAttacking)
        {
            Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Roar");
        }
        else if (Physics.CheckSphere(Back.position, 5, PlayerMask) && !isAttacking)
        {
            Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Emerge");
        }
    }
    private void StopGettingRotatedIdiot()
    {
        Move = false;
        Rotate = false;
    }
}
