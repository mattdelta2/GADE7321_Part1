using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public void SaveElements(string[] elements)
    {
        string path = Application.persistentDataPath + "/Elements.txt";
        File.WriteAllLines(path, elements);
        Debug.Log("elements saved to :" + path);
    }

  
}
