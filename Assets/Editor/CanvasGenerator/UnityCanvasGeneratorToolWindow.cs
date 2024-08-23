using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.VersionControl;
using UnityEditor.Search;
using System.IO;

namespace MF.Tools
{
    public class UnityCanvasGeneratorToolWindow : EditorWindow
    {
        private float someValue;
        private string canvasName;
        private Object file;
        private Label messages;

        private int selectedIndex = 0;
        private readonly string[] options = new string[] { "Penpot SVG", "JSON", "XML" };
        private readonly List<string> choices = new List<string> { "Penpot SVG", "JSON", "XML" };

        private CanvasGeneratorTool generatorTool;


        [MenuItem("Tools/Unity Canvas Generator")]
        public static void ShowWindow()
        {
            var window = GetWindow<UnityCanvasGeneratorToolWindow>();
            window.titleContent = new GUIContent("Unity Canvas Generator");
        }

        //private void OnGUI()
        //{
        //    GUILayout.Label("Canvas Generator Settings", EditorStyles.boldLabel);
        //    canvasName = EditorGUILayout.TextField("Canvas Name", canvasName);
        //    selectedIndex = EditorGUILayout.Popup("Convert Options", selectedIndex, options);
        //    file = EditorGUILayout.ObjectField("File", file, typeof(Object), false);

        //    GUILayout.Label("Convert from " + options[selectedIndex]);

        //    if (file != null && GUILayout.Button("Convert"))
        //    {
        //        Debug.Log($"{canvasName} was created, from {file}.");
        //    }
        //}

        public void CreateGUI()
        {
            var titleLabel = new Label("Canvas Generator Settings")
            {
                style = { unityFontStyleAndWeight = FontStyle.Bold }
            };

            var canvasNameField = new TextField("Canvas Name")
            {
                value = canvasName
            };
            canvasNameField.RegisterValueChangedCallback(evt => canvasName = evt.newValue);

            var convertOptionsField = new PopupField<string>("File Type Options", choices, selectedIndex);
            convertOptionsField.RegisterValueChangedCallback(evt => 
            {
                selectedIndex = choices.IndexOf(evt.newValue);
                convertOptionsField.value = evt.newValue;
            });

            var fileField = new ObjectField("File")
            {
                label = "File to Convert",
                objectType = typeof(Object)
            };
            fileField.RegisterValueChangedCallback(evt => file = evt.newValue);

            var convertButton = new Button(Convert)
            {
                text = "Convert"
            };

            messages = new Label();
                
            // Add UI elements to the root visual element
            rootVisualElement.Add(titleLabel);
            rootVisualElement.Add(canvasNameField);
            rootVisualElement.Add(convertOptionsField);
            rootVisualElement.Add(fileField);
            rootVisualElement.Add(messages);
            rootVisualElement.Add(convertButton);
        }

        private void Convert()
        {
            if (file != null)
            {
                string path = AssetDatabase.GetAssetPath(file);
                Debug.Log($"{canvasName} was created from {file.name}.");

                if (selectedIndex == (int)FormatType.PenpotSVG)
                {
                    if (Path.GetExtension(path).ToLower() == ".svg")
                    {
                        var rawData = File.ReadAllText(path);
                        generatorTool = new CanvasGeneratorTool(FormatType.PenpotSVG, rawData);
                        generatorTool.GenerateCanvas();
                    }
                    else
                        messages.text = "File format is incompatible with the selected File Type Option";
                }
            }
        }
    }
}
