using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranTimeGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public station s1;
    public station s2;
    public station s3;
    public float max1 = 20;
    public float max2 = 20;
    public float max3 = 20;
    public float max = 30;

    void Start()
    {
        Invoke("gen1", Random.Range(1f, max));
        Invoke("gen2", Random.Range(1f, max));
        Invoke("gen3", Random.Range(1f, max));
    }

    // Update is called once per frame
    void Update()
    {
        //max1 = Random.Range(1f, max1);
        //max2 = Random.Range(1f, max2);
        //max3 = Random.Range(1f, max3);
    }

    void gen1()
    {
        s1.start = true;
        Invoke("gen1", Random.Range(1f, max1));
    }
    void gen2()
    {
        s2.start = true;
        Invoke("gen2", Random.Range(1f, max2));
    }
    void gen3()
    {
        s3.start = true;
        Invoke("gen3", Random.Range(1f, max3));
    }

}
