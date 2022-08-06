using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public static T ParseJSON<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }
}
