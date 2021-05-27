using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;	// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded

    private Rigidbody2D rb;
    private bool jump = false;
    private bool m_Grounded;

    public float jumpForce = 40f;
    public Animator animator;

    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;
	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            animator.SetBool("Jump", true);
            jump = true;
        }
    }

    void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
		m_Grounded = false;

         if(jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false; 
            animator.SetBool("Jump", true); 
        }
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
    }

    public void onLanding()
    {
        animator.SetBool("Jump", false);
    }
}
