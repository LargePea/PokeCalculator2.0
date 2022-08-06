using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinPokeball : MonoBehaviour
{
    [SerializeField] private Image _pokemon;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShowPokemon(Sprite pokemonSprite)
    {
        _pokemon.sprite = pokemonSprite;
        _animator.SetBool("ShowPokemon", true);
    }

    public void HidePokemon()
    {
        _animator.SetBool("ShowPokemon", false);
    }
}
