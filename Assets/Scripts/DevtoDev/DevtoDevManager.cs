using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevtoDevManager : MonoBehaviour
{
    public string androidAppId;
    public string androidAppSecret;
    public int level;
    // Start is called before the first frame update
    private void Awake() {
        DevToDev.Analytics.UserId = SystemInfo.deviceUniqueIdentifier;
        DevToDev.Analytics.CurrentLevel(level);
        #if UNITY_ANDROID
           DevToDev.Analytics.Initialize(androidAppId, androidAppSecret);
        #endif
    }
    public void Analize()
    {
        DevToDev.Analytics.StartSession();
        level++;
        DevToDev.Analytics.LevelUp(level);
        DevToDev.Analytics.EndSession();
    }
}
