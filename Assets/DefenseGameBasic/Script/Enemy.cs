using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IComponentChecking
{
    private Animator m_anim;
    private Player m_player;
    private Rigidbody2D m_rb;
    public float speed;
    public float atkDistance;

    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        m_player = FindObjectOfType<Player>();
    }
    void Start()
    {
       
    }
    public bool IsComponentsNull()
    {
        return m_anim == null || m_rb == null || m_player == null;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsComponentsNull()) return;

        if (Vector2.Distance(m_player.transform.position,
            transform.position) <= atkDistance)
        {
            m_anim.SetBool(Const.ATTACK_ANIM, true);
            m_rb.velocity = Vector2.zero;
        }
        else
        {
            m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);
        }

    }
}
