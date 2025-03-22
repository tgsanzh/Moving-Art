using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endBlock : MonoBehaviour
{
    public static int pixels;
    private void Update()
    {
        if(pixels == 4)
        {
            if (this.transform.position.x >= 6)
            {
                this.transform.position += new Vector3(-12f, 0, 0);
            }
            else if (this.transform.position.x <= -6)
            {
                this.transform.position += new Vector3(12f, 0, 0);
            }
            else if (this.transform.position.y >= 4.5)
            {
                this.transform.position += new Vector3(0, -12f, 0);
            }
            else if (this.transform.position.y <= -7.5)
            {
                this.transform.position += new Vector3(0, 12f, 0);
            }
        }
        else if(pixels == 5) 
        {
            if (this.transform.position.x >= 7.5f)
            {
                this.transform.position += new Vector3(-15f, 0, 0);
            }
            else if (this.transform.position.x <= -7.5f)
            {
                this.transform.position += new Vector3(15f, 0, 0);
            }
            else if (this.transform.position.y >= 5.75f)
            {
                this.transform.position += new Vector3(0, -15f, 0);
            }
            else if (this.transform.position.y <= -9.25f)
            {
                this.transform.position += new Vector3(0, 15f, 0);
            }
        }
        
    }
}
