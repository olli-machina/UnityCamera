using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<string> pokemonList;
    public PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        pokemonList = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            for (int i = 0; i < pokemonList.Count; i++)
            {
                if (pokemonList[i] != null)
                {
                    Debug.Log("Added: " + pokemonList[i]);
                }
            }
        }
    }

    public void AddToList()
    {
        for (int i =0; i < playerMove.inRangePokemon.Length; i++)
        { if (pokemonList.Contains(name))
            {
                //code here for grouping photos
            }
            else
            {
                if (playerMove.inRangePokemon[i] != null)
                {
                    pokemonList.Add(playerMove.inRangePokemon[i].name);
                    Debug.Log(playerMove.inRangePokemon[i].name);
                }
                else
                    Debug.Log("nope");
            }
        }
    }
}
