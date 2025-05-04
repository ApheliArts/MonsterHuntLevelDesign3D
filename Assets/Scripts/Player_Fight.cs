using UnityEngine;

public class Player_Fight : MonoBehaviour
{
    public FightStat Player;
    public FightStat Enemy;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Player Attack
    void Update()
    {
        //Player Attack
        Enemy.TakeDamage(Player.damage);
        //Player Dodge

        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
