using UnityEngine;
using UnityEngine.UI;
public class bomd : MonoBehaviour
{
    public GameObject bomd1;
    public GameObject off;
    public GameObject on;
    public float CoolingTime = 30f;
    public float durration = 5f;

    float op = 0;

    void Update()
    {
        CoolingTime -= Time.deltaTime;
        if (CoolingTime <= 0) 

        {
            off.SetActive(true);
            on.SetActive(false);

            if (Input.GetKey("x"))
                {
                op = 1;
            }

        }

        if (op == 1)
            {
                Instantiate(bomd1, new Vector3(Random.Range(350f, -350f), 50, Random.Range(250f, -250f)), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(bomd1, new Vector3(Random.Range(350f, -350f), 50, Random.Range(250f, -250f)), Quaternion.Euler(new Vector3(0, 0, 0)));
            durration -= Time.deltaTime;
                if (durration <= 0)
                {
                    CoolingTime = 30f;
                    durration = 5f;
                op = 0;
            }
            on.SetActive(true);
            off.SetActive(false);

        }
    }
}
