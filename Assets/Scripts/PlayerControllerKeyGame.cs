using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerKeyGame : MonoBehaviour
{

    [SerializeField] float _hiz = 10f;
    float _derece = 180f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Hareket();
    }

    void Hareket()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * _hiz * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, _derece, 0);
        }

    }

}
