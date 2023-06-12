using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour
{
    private Animator anim;
    private bool acceptInput = true;

    public AnimationClip punchClip; 

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        if (punchClip != null )
        {
            AnimationEvent punchDone = new AnimationEvent();
            punchDone.time = punchClip.length;
            punchDone.functionName = "CooldownDone";
            punchClip.AddEvent(punchDone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (acceptInput)
        {
            InputHandler();
        }
    }

    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("PunchTrigger");
            acceptInput = false;
        }
        anim.SetBool("WalkBool", Input.GetKey(KeyCode.W));
    }

    private void CooldownDone()
    {
        acceptInput = true;
    }
}
