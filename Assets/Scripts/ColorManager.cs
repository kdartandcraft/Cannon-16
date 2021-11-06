using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    public Color BallColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color BallColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.BallColor = BallColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BallColor = data.BallColor;
        }
    }
}
