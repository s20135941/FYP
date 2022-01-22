using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public int HPHeal;

    public GameObject fpsPlayer;

    public UIManager _uiManager_;
    public PlayerCharacterController playerCC;
    
    public int playerHealth;

    //public AudioClip pickupSound;
    //private AudioSource pickupAudio;
    public GameObject soundEffect;
    private void Start()
    {
        _uiManager_ = GameObject.Find("Canvas").GetComponent<UIManager>();

        //if(pickupSound != null)
        //{
        //    pickupAudio = gameObject.AddComponent<AudioSource>();
        //    pickupAudio.playOnAwake = false;
        //    pickupAudio.volume = 0.2f;
        //    pickupAudio.Stop();
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonPlayer")
        {
            HealthPlayer(HPHeal);
            //if (pickupSound != null)
            //{
            //    pickupAudio.clip = pickupSound;
            //    pickupAudio.Play();
            //}
            soundEffect.SetActive(true);
            gameObject.SetActive(false);
            Invoke("PickedUp", 1.0f);
        }
    }

    void PickedUp()
    {
        Destroy(soundEffect);
    }

    void HealthPlayer(int healpoint)
    {
        fpsPlayer = GameObject.Find("FirstPersonPlayer");
        playerCC = fpsPlayer.GetComponent<PlayerCharacterController>();
        playerHealth = playerCC.currentHP;
        playerHealth += healpoint;
        playerCC.currentHP = playerHealth;
        _uiManager_.SetHealth(playerHealth);
    }
}
