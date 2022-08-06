using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PokemonCell : MonoBehaviour
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Image _pokemonSprite;
    private Pokemon _pokemon;

    [SerializeField] private UnityEvent<Sprite> OnSelectPokemon = new UnityEvent<Sprite>();

    private void Awake()
    {
        _pokemonSprite.sprite = _pokemon != null ? _pokemon.PokemonSprite : _defaultSprite;
    }

    public void SelectedPokemon()
    {
        //Check if pokemon is null
        
        
        if(_pokemon == null) { } //if null send to creation screen
        else { } //if not display moves on the bottom

        //both with trigger the pokeball spin
        OnSelectPokemon.Invoke(_pokemonSprite.sprite);
    }

    public void SavePokemon(Pokemon pokemon)
    {
        _pokemon = pokemon;
        _pokemonSprite.sprite = _pokemon.PokemonSprite;
    }
}
