using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "data/Mineral")]
public class Mineables : ScriptableObject
{
    public TileBase tile;
    public item item;
    public int weight;
    public int count;
    public float spread;

    //add list support public item itemdrop;
    //spread
    //tools needed
    //tier



    //future
    //spawn rate
    //spawn tiles
    //spawn maps
}