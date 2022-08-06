using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class PokemonSearch : MonoBehaviour
{
    public UnityEvent<Pokemon> OnFoundPokemon;

    public void StartSearch(string pokemonName)
    {
        StartCoroutine(SearchForPokemon(pokemonName));
    }

    private IEnumerator SearchForPokemon(string pokemonName)
    {
        pokemonName = pokemonName.ToLower();
        JSONPokemon jSONPokemon = JSONGetter.SearchForJSON<JSONPokemon>($"pokemon/{pokemonName}");

        if(jSONPokemon.name == null)
        {
            //prompt player to input again
        }

        else
        {
            //load pokemon image
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(jSONPokemon.sprites.front_default))
            {
                request.SendWebRequest();
                while (!request.isDone)
                {
                    yield return null;
                }

                switch (request.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(": Error: " + request.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(": HTTP Error: " + request.error);
                        break;
                    case UnityWebRequest.Result.Success:

                        Texture2D texture = DownloadHandlerTexture.GetContent(request);

                        string[] types = new string[2];
                        for (int i = 0; i < jSONPokemon.types.Length; i++) types[i] = jSONPokemon.types[i].type.name;

                        Pokemon pokemon = new Pokemon()
                        {
                            Name = jSONPokemon.name,
                            PokemonSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero),
                            ElementTypes = types
                        };
                        OnFoundPokemon.Invoke(pokemon);
                        break;
                }
            }

        }
    }
}
