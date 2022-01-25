using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaScript : MonoBehaviour
{
    private float x_direction;
    private float y_direction;
    private string status;
    public GameObject bacteria;
    // Start is called before the first frame update
    void Start()
    {
        status = "through";
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(x_direction, y_direction, 0f);
    }

    IEnumerator Move(){
        while(true){
            if(status == "through"){
                x_direction = Random.Range(-5.0f,5.0f) * Time.deltaTime;
                y_direction = Random.Range(-5.0f,5.0f) * Time.deltaTime;
                status = "changeDirection";
            }else if(status == "changeDirection"){
                x_direction = 0f * Time.deltaTime;
                y_direction = 0f * Time.deltaTime;
                status = "proliferation";
            }else if(status == "proliferation"){
                Instantiate(bacteria,transform.position,transform.rotation);
                status = "through";
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
