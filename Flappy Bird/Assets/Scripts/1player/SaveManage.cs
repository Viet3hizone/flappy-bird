using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class SaveManage
{
    public int indexsound;
    public int indexmusic;
    public SaveManage()
    {
        indexsound = 1;
        indexmusic = 1;
    }
    public static SaveManage CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<SaveManage>(jsonString);
    }

    public string SaveToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
