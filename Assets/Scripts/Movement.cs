using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] public int pixels = 4;
    private Vector3 startpos;
    private Vector3 startposchosen;
    private GameObject curblock;
    private bool x = false;
    private Vector2 target;
    [SerializeField] private float speed;
    [SerializeField] private Transform blockParent;
    [SerializeField] private Transform chosenParent;

    [SerializeField] private Transform controll_pos_block_left, controll_pos_block_right;
    [SerializeField] private Systems systems;
    private void Start()
    {
        endBlock.pixels = pixels;
        blockParent = GameObject.Find("Blocks").transform;
        chosenParent = GameObject.Find("Chosen").transform;
        controll_pos_block_left = GameObject.Find("controllBlock1").transform;
        controll_pos_block_right = GameObject.Find("controllBlock2").transform;
    }
    private void Update()
    {

        chosenParent.position = Vector2.Lerp(chosenParent.position, target, speed * Time.deltaTime);

    }
    public void OnPointerDown(PointerEventData eventData)
    {
;

        startpos = Camera.main.ScreenToWorldPoint(eventData.position);
        RaycastHit2D hit = Physics2D.Raycast(startpos, Vector2.zero);
        if (hit && hit.transform.position.x > controll_pos_block_left.position.x && hit.transform.position.x < controll_pos_block_right.position.x
            && hit.transform.position.y > controll_pos_block_right.position.y && hit.transform.position.y < controll_pos_block_left.position.y)
        {
            curblock = hit.collider.gameObject;
            chosenParent.transform.position = Vector3.zero;
            target = Vector3.zero;
            startposchosen = chosenParent.position;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {


        if (curblock == null) return;
        Vector3 curpos = Camera.main.ScreenToWorldPoint(eventData.position);
        if(chosenParent.childCount == 0)
        {
            if (math.abs(eventData.delta.x) > math.abs(eventData.delta.y))
            {
                Vector2 pos = new Vector2(curblock.transform.position.x - 100, curblock.transform.position.y);
                RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.right, 150);
                foreach (RaycastHit2D hit in hits)
                {
                    hit.transform.parent = chosenParent;
                    x = true;
                }
                for (int i = 0; i < pixels * 3; i++) //0, 1, 2, 3, 4, 5, 6
                {
                    if(i < pixels)
                    {
                        hits[i].collider.GetComponent<SpriteRenderer>().color = hits[i + pixels].collider.GetComponent<SpriteRenderer>().color;

                    }
                    else if (i >= pixels * 3 - pixels)
                    {
                        hits[i].collider.GetComponent<SpriteRenderer>().color = hits[i - pixels].collider.GetComponent<SpriteRenderer>().color;

                    }
                }

            }
            else
            {
                Vector2 pos = new Vector2(curblock.transform.position.x, curblock.transform.position.y - 100);
                RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.up, 150);
                foreach (RaycastHit2D hit in hits)
                {
                    hit.transform.parent = chosenParent;
                    x = false;
                }
                for (int i = 0; i < pixels * 3; i++) //0, 1, 2, 3, 4, 5, 6
                {
                    if (i < pixels)
                    {
                        hits[i].collider.GetComponent<SpriteRenderer>().color = hits[i + pixels].collider.GetComponent<SpriteRenderer>().color;

                    }
                    else if (i >= pixels * 3 - pixels)
                    {
                        hits[i].collider.GetComponent<SpriteRenderer>().color = hits[i - pixels].collider.GetComponent<SpriteRenderer>().color;

                    }
                }
            }
        }
        if (x)
        {
            target = startposchosen + new Vector3(curpos.x - startpos.x, 0, 0);
        }
        else
        {
            target = startposchosen + new Vector3(0, curpos.y - startpos.y, 0);
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        systems.isWinFull();
        if (curblock == null) return;
        if (x)
        {
            if(chosenParent.position.x % 1 > 0.5)
            {
                chosenParent.position += new Vector3(1 - chosenParent.position.x % 1, 0, 0);
            }
            else if (chosenParent.position.x % 1 < -0.5)
            {
                chosenParent.position -= new Vector3(1 + chosenParent.position.x % 1, 0, 0);
            }
            else if(chosenParent.position.x % 1 > 0)
            {
                chosenParent.position -= new Vector3(chosenParent.position.x % 1, 0, 0);
            }
            else if (chosenParent.position.x % 1 < 0)
            {
                chosenParent.position -= new Vector3(chosenParent.position.x % 1, 0, 0);
            }
        }
        else
        {
            if (chosenParent.position.y % 1 > 0.5)
            {
                chosenParent.position += new Vector3(0, 1 - chosenParent.position.y % 1, 0);
            }
            else if (chosenParent.position.y % 1 < -0.5)
            {
                chosenParent.position -= new Vector3(0, 1 + chosenParent.position.y % 1, 0);
            }
            else if (chosenParent.position.y % 1 > 0)
            {
                chosenParent.position -= new Vector3(0, chosenParent.position.y % 1, 0);
            }
            else if (chosenParent.position.y % 1 < 0)
            {
                chosenParent.position -= new Vector3(0, chosenParent.position.y % 1, 0);
            }
        }
        target = chosenParent.position;
        for (int i = chosenParent.childCount - 1; i > -1; i--)
        {

            chosenParent.GetChild(0).parent = blockParent;

        }
        curblock = null;
    }


}