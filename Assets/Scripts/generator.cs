using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ready = true;
    public GameObject stationx;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(this.name + " exit " + other.tag);
        stationx.GetComponent<station>().generate();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Bar")
    //    {
    //        //Debug.Log(this.name + " enter " + other.tag);
    //    }
    //}



}
