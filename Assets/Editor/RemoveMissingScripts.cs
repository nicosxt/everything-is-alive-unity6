using UnityEditor;
using UnityEngine;

public class RemoveMissingScripts : EditorWindow
{
    [MenuItem("Tools/Remove Missing Scripts In Scene")]
    static void RemoveMissingScriptsInScene()
    {
        int count = 0;

        foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>())
        {
            // Remove missing scripts from this GameObject
            int removed = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
            if (removed > 0)
            {
                count += removed;
                Debug.Log($"Removed {removed} missing scripts from GameObject: {go.name}", go);
                EditorUtility.SetDirty(go);
            }
        }

        Debug.Log($"Total missing scripts removed: {count}");
    }
}
