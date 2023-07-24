using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using System;
public class DatabaseManager : MonoBehaviour
{
    public InputField m_InputName;
    public InputField m_InputAge;
    public Text m_TextName;
    public Text m_TextAge;
    public Text m_TextId;

    private string Id;
    DatabaseReference reference;
    // Start is called before the first frame update
    private void Awake() {
        Id=SystemInfo.deviceUniqueIdentifier;
    }
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    private void Update() {
        m_TextId.text=Id;
    }
    public void NewUser() {
        User user = new User(m_InputName.text, int.Parse(m_InputAge.text));
        string json = JsonUtility.ToJson(user);

        reference.Child("users").Child(Id).SetRawJsonValueAsync(json);
    }
    public void GetDetail() 
    {
        StartCoroutine(GetName((string name)=>{
            m_TextName.text=name;
        }));
        StartCoroutine(GetAge((int age)=>{
            m_TextAge.text=age.ToString();
        }));
    }
    private IEnumerator GetName(Action<string> onCallback)
    {
        var data=reference.Child("users").Child(Id).Child("username").GetValueAsync();
        yield return new WaitUntil(predicate: ()=>data.IsCompleted);
        if(data!=null)
        {
            DataSnapshot snapshot = data.Result;
            onCallback.Invoke(snapshot.Value.ToString());
        }
    }
    private IEnumerator GetAge(Action<int> onCallback)
    {
        var data=reference.Child("users").Child(Id).Child("age").GetValueAsync();
        yield return new WaitUntil(predicate: ()=>data.IsCompleted);
        if(data!=null)
        {
            DataSnapshot snapshot = data.Result;
            onCallback.Invoke(int.Parse(snapshot.Value.ToString()));
        }
    }
    public void UpdateDetails()
    {
        reference.Child("users").Child(Id).Child("username").SetValueAsync(m_InputName);
        reference.Child("users").Child(Id).Child("age").SetValueAsync(m_InputAge);
    }
}
