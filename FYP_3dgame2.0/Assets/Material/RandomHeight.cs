using UnityEngine;

public class RandomHeight : MonoBehaviour
{
    public GameObject monster;
    public int amount;
    public float CreatTime = 5f;
    public float starting = 5f;
    public float Endting = 15f;
    public int high = 1;

    void Update()
    {        
        CreatTime -= Time.deltaTime;
        


        if (amount > 0)
        {

            if (CreatTime <= 0)
            {

                Instantiate(monster, new Vector3(Random.Range(100f, -100f), high, Random.Range(-200f, 200f)), Quaternion.Euler(new Vector3(0, 0, 0)));

                CreatTime = Random.Range(starting, Endting);
                //Random<.@.>
                // CreatTime = 4;
                amount = amount - 1;
            }

            
        }
    }
}

