import UnityEngine as unity

objects = unity.Object.FindObjectsOfType(unity.GameObject)

#finding game objects
for go in objects:
    unity.Debug.Log(go.name)