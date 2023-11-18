using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem boardParticleSystem;

    //void Start()
    //{
    //    boardParticleSystem = GetComponent<ParticleSystem>();
    //}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            boardParticleSystem.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            boardParticleSystem.Stop();
        }
    }
}
