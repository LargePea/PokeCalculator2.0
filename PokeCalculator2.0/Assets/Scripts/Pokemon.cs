using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public string Name { get; set; }
    public Sprite PokemonSprite { get; set; }
    public string[] ElementTypes { get; set; }
    public PokemonMove[] PokemonMoves { get; set; } = new PokemonMove[4];

}
