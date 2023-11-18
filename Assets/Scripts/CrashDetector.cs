using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] AudioClip crashSFX;
    [SerializeField] float LoadSceneDelay  = 0.5f;
    [SerializeField] ParticleSystem crashEffect;

    AudioSource audioSrc;
    bool didCrash = false;
    //PlayerController playerController;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && !didCrash)
        {
            didCrash = true;
            FindObjectOfType<PlayerController>().ForbidMoving();
            crashEffect.Play();
            audioSrc.PlayOneShot(crashSFX);
            Invoke("ReloadScene", LoadSceneDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
