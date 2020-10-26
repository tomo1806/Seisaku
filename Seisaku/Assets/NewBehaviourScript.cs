using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject clickedGameObject;
    Quaternion q;
    private int hc = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            Debug.Log(hit2d);
            clickedGameObject = null;

            
            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
                var pos = transform.rotation;
                //右に進行中にクリック
                if (hit2d.collider.CompareTag("Syuzinkou"))
                {
                    if(hc == 0)
                    {
                        pos.y = 180;
                        transform.rotation = pos;
                        hc = 1;
                        Debug.Log("左に転換");
                    }
                    //左に進行中にクリック
                    else
                    {
                        pos.y = 0;
                        transform.rotation = pos;
                        hc = 0;
                        Debug.Log("右に転換");
                    }

                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//衝突したとき
    {
        //右の壁に当たったら
        if (collision.gameObject.tag == "Outerframer")
        {
            var pos = transform.rotation;
            pos.y = 180;
            transform.rotation = pos;
            hc = 1;
            Debug.Log("左に転換");
        }
        //左の壁に当たったら
        if (collision.gameObject.tag == "Outerframel")
        {
            var pos = transform.rotation;
            pos.y = 0;
            transform.rotation = pos;
            hc = 0;
            Debug.Log("右に転換");
        }
        
    }
}
