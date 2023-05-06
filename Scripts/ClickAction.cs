using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickAction : MonoBehaviour
{
    public GameManager Mineables;
    public Tilemap MinableMap;
    public GameObject itemPrefab;

    // Update is called once per frame
    void Update()
    {
        //i will do my best to document this, but here be dragons
        if(Input.GetMouseButtonDown(0))
        {
            //mouse input recieved, activate mineing
            if(
                //check if tile at mouse location exists, if not, don't bother further checks.
                MinableMap.GetTile(
                    MinableMap.WorldToCell(new Vector3(
                        //screen to world point is finicky so im scared to optimise this.
                        Camera.main.ScreenToWorldPoint(
                            new Vector3(Input.mousePosition.x, 
                                Input.mousePosition.y, 
                                0.0f
                            )
                        ).x,
                        Camera.main.ScreenToWorldPoint(
                            new Vector3(Input.mousePosition.x, 
                                Input.mousePosition.y, 
                                0.0f
                            )
                        ).y,
                        0)))
                 != null
            )
            {
                //this will be implemented for resource spawn count

                //for (int i = 0; i < length; i++)
                //{
                    
                //}

                //creates new pickup-able item prefab at mouse location
                GameObject newitem = Instantiate(itemPrefab, new Vector2(
                        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4.0f)
                        ).x,
                        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4.0f)
                        ).y
                    ), Quaternion.identity);


                //find mineral with the tile, and set that to mat
                Mineables mat = Mineables.minerals.Find(x => 
                x.tile == 
                MinableMap.GetTile(
                    MinableMap.WorldToCell(
                        Camera.main.ScreenToWorldPoint(
                            new Vector3(Input.mousePosition.x, 
                                Input.mousePosition.y, 
                                0.0f)))));

                //change newitem's internal vars to match the minerals
                newitem.GetComponent<Itemspawnable>().item = mat.item;
                newitem.GetComponent<SpriteRenderer>().sprite = mat.item.sprite;
                
                
            }
        }
    }
}
