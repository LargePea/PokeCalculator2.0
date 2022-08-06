using System.Collections;
using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class JSONGetter : MonoBehaviour
{
    public static T SearchForJSON<T>(string name) where T : new()
    {
        var json = string.Empty;

        using (WebClient webClient = new WebClient())
        {
            try
            {
                json = webClient.DownloadString($"https://pokeapi.co/api/v2/{name}");
            }
            catch (Exception) { Debug.LogError($"Could not find requested pokemon at: https://pokeapi.co/api/v2/pokemon/{name}"); }

            return !string.IsNullOrEmpty(json) ? JSONReader.ParseJSON<T>(json) : new T();
        }
    }


}
