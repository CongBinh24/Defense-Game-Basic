using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IComponentChecking
{
    public float atkRate;
    private float m_curAtkRate;
    private bool m_isAttacked;
    private Animator m_anim;
    private bool m_isDead;
    private GameManager m_gm;

    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_curAtkRate = atkRate;
        m_gm = FindObjectOfType<GameManager>();
    }
    void Start()
    {

    }
    public bool IsComponentsNull()
    {
        return m_anim == null || m_gm == null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1 && Input.GetMouseButtonDown(0) && !m_isAttacked)
        {
            if (IsComponentsNull()) return;

            m_anim.SetBool(Const.ATTACK_ANIM, true);
            m_isAttacked = true;
        }

        if (m_isAttacked) 
        {
            m_curAtkRate -= Time.deltaTime;
            if(m_curAtkRate <= 0)
            {
                m_isAttacked =false;
                m_curAtkRate = atkRate;
            }
        }

    }

    public void ResetAtkAnim()
    {
        if (IsComponentsNull()) return;
        m_anim.SetBool(Const.ATTACK_ANIM, false);

    }
    public void PlayAtkSound()
    {
        if (m_gm.auCtr)
            m_gm.auCtr.PlaySound(m_gm.auCtr.playerAtk);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (IsComponentsNull()) return;

        if (col.CompareTag(Const.ENEMY_WEAPON_TAG) && !m_isDead)
        {
            m_anim.SetTrigger(Const.DEAD_ANIM);
            m_isDead = true;
            gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
            m_gm.GameOver();
        }
    }


}
