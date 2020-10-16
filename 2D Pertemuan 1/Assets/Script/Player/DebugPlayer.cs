using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayer : MonoBehaviour
{
    public bool isDebuging;
    public PlayerManager playerManager;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Debuging");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDebuging)
        {
            if (playerManager.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                Debug.Log("Idle");
            }
            else if (playerManager.animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                Debug.Log("Run");
            }
            else if (playerManager.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            {
                Debug.Log("Attack1");
            }
            else if (playerManager.animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                Debug.Log("Jump");
            }
            else if (playerManager.animator.GetCurrentAnimatorStateInfo(0).IsName("Fall"))
            {
                Debug.Log("Fall");
            }
        }
        
    }
}
