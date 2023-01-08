//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{
    // Start is called before the first frame update
    public char source;
    public bool splitted = false;
    public bool collided = false;
    public float speed = 0.005f;
    public int id = 0;
    public Sprite red;
    private SpriteRenderer sp;
    public GameObject owner_station;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        if(source == 'b')
            transform.Rotate(new Vector3(0, 0, 90));
    }

    // Update is called once per frame
    void Update()
    {
        if (source == 'l')
        {
            this.transform.position += new Vector3(speed, 0, 0);
        }
        else if (source == 'r')
        {
            this.transform.position -= new Vector3(speed, 0, 0);
        }
        else if (source == 'b')
        {
            this.transform.position += new Vector3(0, speed, 0);
        }
        else if (source == 't')
        {
            this.transform.position -= new Vector3(0, speed, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bar" && other.gameObject.GetComponent<bar>().id != this.id)
        {
            Debug.Log(this.name + "enter" + other.tag);
            collided = true;
            sp.sprite = red;
        }
    }

    private void OnDestroy()
    {
        owner_station.GetComponent<station>().counter_sent++;
    }

}
