using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace MF.Tools
{
    public class UnityCanvasGenerator : EditorWindow
    {
        private float someValue;
        private string canvasName;
        private Color someColor;
        private int selectedIndex;
        private string[] options = new string[] { "HTML", "JSON", "XML" };


        [MenuItem("Tools/Unity Canvas Generator")]
        public static void ShowWindow()
        {
            GetWindow<UnityCanvasGenerator>("Unity Canvas Generator");
        }

        private void OnGUI()
        {
            GUILayout.Label("Canvas Generator Settings", EditorStyles.boldLabel);
            canvasName = EditorGUILayout.TextField("Canvas Name", canvasName);
            selectedIndex = EditorGUILayout.Popup("Convert Options", selectedIndex, options);

            GUILayout.Label("Convert from " + options[selectedIndex]);

            if (GUILayout.Button("Convert"))
            {
                Debug.Log($"{canvasName} was created, converted from type {options[selectedIndex]}.");
            }


        }
    }
}
