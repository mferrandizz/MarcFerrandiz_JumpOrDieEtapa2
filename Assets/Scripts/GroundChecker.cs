using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    public static bool isGrounded;
    public PlayerMovement player;

    void Awake()
    {
        player = GameObject.Find("rogue").GetComponent<PlayerMovement>();
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
        player.isGrounded = true;
        player.anim.SetBool("Jump", false);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.isGrounded = false;
    }

}
