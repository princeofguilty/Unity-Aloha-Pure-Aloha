using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using System;
using TMPro;

public class station : MonoBehaviour
{
    // Start is called before the first frame update
    public static int lamda = 3;
    public char position;
    public GameObject[] bars;
    public int counter_sent = 0;
    public int counter_recieved = 0;
    public int success_R_ = 0;
    public int failure_R_ = 0;
    public float success_S_ = 0;
    public float failure_S_ = 0;
    public GameObject generator;
    public int start_id = 0;
    public bool start = false;
    private generator g;
    private List<int> bad_ids = new List<int>();
    private List<int> good_ids = new List<int>();
    private int last_good = 0;

    public TextMeshPro lamda_textbox;

    void Start()
    {
        g = generator.gameObject.GetComponent<generator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            generate();
            start = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name + " enter " + other.tag);
        bar b = other.GetComponent<bar>();
        if (b.source != this.position)
        {
            if (bad_ids.Contains(b.id) || good_ids.Contains(b.id))
            {
                Destroy(other.gameObject);
                return;
            }

            if (b.collided)
            {
                //counter_recieved = 0;
                failure_R_++;
                bad_ids.Add(b.id);
                counter_recieved = last_good;
                b.owner_station.GetComponent<station>().failure_S_ += 0.5f;
            }
            else
            {
                counter_recieved++;
                if (counter_recieved % 5 == 0 && last_good != counter_recieved)
                {
                    success_R_++;
                    b.owner_station.GetComponent<station>().success_S_ += 0.5f;
                    last_good = counter_recieved;
                    good_ids.Add(b.id);
                }
            }


            Destroy(other.gameObject);
        }
    }

    public void generate()
    {
        if (counter_sent == 6 + 5 + 5)
            counter_sent = 0;
        if (counter_sent < 5)
        {
            var x = Instantiate(bars[counter_sent]);
            x.transform.position = g.transform.position;
            var b = x.GetComponent<bar>();
            b.source = this.position;
            b.id = start_id;
            b.owner_station = gameObject;
            counter_sent++;
        }
        else if (counter_sent == 5)
        {
            start_id += 3;
            start = false;
            counter_sent++;
        }
        else if (counter_sent == 6)
        {
            return;
        }
    }
}