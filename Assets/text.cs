using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class text : MonoBehaviour
{

    public GameObject stationx;
    private station holder;
    public TextMeshPro t;
    // Start is called before the first frame update
    void Start()
    {
        holder = stationx.GetComponent<station>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "success:" + holder.success_R_ +"\nfailure:" + holder.failure_R_;
        t.text = "sucess(S):" + holder.success_S_ + "\nfailure(S):"+holder.failure_S_ +
            "\nsuccess(R):"+holder.success_R_+"\nfailure(R):"+holder.failure_R_;
        /* sucess(S):
            failure(S):
            sucess(R):
            failure(R):
        */
    }
}
