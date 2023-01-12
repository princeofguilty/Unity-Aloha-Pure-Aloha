using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ranTimeGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public station s1;
    public station s2;
    public station s3;
    public float lambda1 = 20;
    public float lambda2 = 20;
    public float lambda3 = 20;
    private float max = 100;
    private float p1;
    private float p2;
    private float p3;

    void Start()
    {
        Invoke("gen1", 0.5f);
        Invoke("gen2", 0.5f);
        Invoke("gen3", 0.5f);
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
        p1 = lambda1 * Mathf.Exp(-lambda1)*100;
        if (Random.Range(0, max)<=p1)
            s1.start = true;
        Invoke("gen1", 0.5f);
    }
    void gen2()
    {
        p2 = lambda2 * Mathf.Exp(-lambda2)*100;
        if (Random.Range(0, max) <= p2)
            s2.start = true;
        Invoke("gen2", 0.5f);
    }
    void gen3()
    {
        p3 = lambda3 * Mathf.Exp(-lambda3)*100;
        if (Random.Range(0, max) <= p3)
            s3.start = true;
        Invoke("gen3", 0.5f);
        //
    }

}
