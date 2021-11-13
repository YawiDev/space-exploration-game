using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;

    void Awake () {
        anim = GetComponentInChildren<Animator>();
    }

    void Update () {
        
    }
}
