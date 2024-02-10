using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    [SerializeField] private PlayerController playerController;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }   

    private void Update()
    {
        animator.SetBool(IS_WALKING, playerController.IsWalking());
    }
}
