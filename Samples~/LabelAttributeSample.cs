using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toolkid.Core.Attribute;

public class LabelAttributeSample : MonoBehaviour
{
    [Label("§Ç¦C")] public int index = 0;
    [Label("°}¦C")] public int[] array = new int[3];
    [Label("Ãþ§O")] public SampleArgs args = new SampleArgs();
    [Label("Ãþ§O°}¦C")] public SampleArgs[] argsArray = new SampleArgs[3];
    [Label("°}¦CÃþ§O")]
    public SampleArgsList arrayUnderArgsList;
    [Label("¶¥¼h°}¦C")]
    public SampleArgsList[] argsListArray;
}
[System.Serializable]
public class SampleArgs {
    [Label("¦WºÙ")] public string name = "";
    [Label("´y­z")] public string description = "";
}
[System.Serializable]
public class SampleArgsList {
    [Label("Ãþ§O°}¦C")]
    public SampleArgs[] argsArray = new SampleArgs[3];
}