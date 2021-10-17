using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMoviment : MonoBehaviour
{
    [SerializeField] float force_impulse;
    [SerializeField] float torque_force;
    [SerializeField] float velocity;
    [SerializeField]Rigidbody rb;
    [SerializeField] GameObject button_shop;
    bool go_moviment = false;
    bool triger = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            go_moviment = true;
        }
        if (go_moviment)
        {
            Moviment();
        }
        
      
    }

    void Moviment()
    {
        button_shop.SetActive(false);

        rb.isKinematic = false;

        rb.velocity = new Vector3( velocity,  force_impulse, transform.position.z);

        rb.AddTorque( 0, 0,torque_force , ForceMode.Force);

        go_moviment = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Piso"))
        {
            if (triger)
            {
                rb.isKinematic = true;
                triger = false;

                StartCoroutine(Timer());
            }
        }

        if (other.gameObject.CompareTag("Destroy Player"))
        {
            GameManager.instance.Set_panel_lose.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Destroy Player"))
        {
            GameManager.instance.Set_panel_lose.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator Timer()
    {
       yield return new  WaitForSeconds(1);
        triger = true;
    }
    
}

